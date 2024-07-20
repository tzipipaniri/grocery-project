using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using פרויקט.BLL;
using פרויקט.Gui;
using פרויקט.Dal;
using פרויקט.Utilies;

namespace פרויקט.Gui
{
    public partial class frmTashlum : Form
    {
        Tashlumim t;
        TashlumimDB tblT;
        PratimOfTashlum pt;
        PratimOfTashlumDB tblPt;
        Customers cust;
        CustomersDB tblCust;
        double sum;
        bool flagOk;
        string status;
        public frmTashlum(double s,Customers c,string custOrBuying)
        {
            InitializeComponent();
            tblCust = new CustomersDB();
            tblT = new TashlumimDB();
            tblPt = new PratimOfTashlumDB();
            sum = s;
            cust = c;
            status = custOrBuying;
            txtCode.Text = tblT.GetNextKey().ToString();
            txtName.Text = cust.ThisCustomers().ToString();
            if (status == "customer")
            {
                lblSunP.Visible = true;
                txtSumP.Visible = true;
            }
            txtSum.Text = s.ToString();
            dateTimePicker1.Value = DateTime.Now;
           // txtsumEveryTashlum.Text = (sum / (Convert.ToInt32(numericUpDown1.Value))).ToString();
        }

        //private void numericUpDown1_Leave(object sender, EventArgs e)
        //{
        //    txtSum.Text = (sum / (Convert.ToInt32(numericUpDown1.Value))).ToString();
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            t = new Tashlumim();
            if (status == "customer")
            {
                cust.ChovCustomer -= Convert.ToDouble(txtSumP.Text);
                tblCust.UpdateRow(cust);
            }
            if (CreateFields(t))
            {
                t.CodeTashlum = Convert.ToInt32(txtCode.Text);
                t.IdCustomer = cust.ThisCustomers().IdCustomer;
                t.NumTashlumim = Convert.ToInt32(numericUpDown1.Value);
                t.SumOfAllTashlum = Convert.ToDouble(txtSum.Text);
                t.Date = dateTimePicker1.Value;
                t.OfenTshlum = "אשראי";
                tblT.AddNew(t);
                DateTime dt = dateTimePicker1.Value;
                for (int i = 0; i < numericUpDown1.Value; i++)
                {
                    pt = new PratimOfTashlum();
                    pt.NumTashlum = i + 1;
                    pt.CodeTashlum = Convert.ToInt32(txtCode.Text);
                    pt.SumForTashlum = Convert.ToDouble(txtSum.Text) / Convert.ToDouble(numericUpDown1.Value);
                    pt.Date = dt;
                    tblPt.AddNew(pt);
                    dt = dt.AddMonths(1);
                }
                MessageBox.Show("תודה שקניתם אצלנו");
                this.Close();
            }
            
        }

            
        
       

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
            groupBox2.Visible = true;
        }

        private void rbMezuman_CheckedChanged(object sender, EventArgs e)
        {
            //t.CodeTashlum =Convert.ToInt32( txtCode.Text);
            
        }
        private bool CreateFields(Tashlumim t)
        {
            flagOk = true;
            errorProvider1.Clear();
           
            try
            {
                if (txtNumTicket.Text == "")
                    throw new Exception("שדה חובה");
                t.NumTicket =txtNumTicket.Text ;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtNumTicket, ex.Message);
                flagOk = false;
            }
            try
            {
                if (maskedTextBox1.Text == "")
                    throw new Exception("שדה חובה");
                t.Tokef = Convert.ToDateTime(maskedTextBox1.Text);
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(maskedTextBox1, ex.Message);
                flagOk = false;
            }
            if (Convert.ToInt32(maskedTextBox1.Text.Substring(0, 2)) > 12 || Convert.ToInt32(maskedTextBox1.Text.Substring(0, 2)) < 0)
            {
                errorProvider1.SetError(maskedTextBox1, " החודש בתוקף לא תקין");
                return false;
            }
            if (Convert.ToInt32(maskedTextBox1.Text.Substring(3, 4)) < 2022)
            {
                errorProvider1.SetError(maskedTextBox1, " השנה בתוקף לא תקין");
                return false;
            }
           
            try
            {
                if (txtIdManOfTicket.Text == "")
                    throw new Exception("שדה חובה");
                t.IdManOfTicket = txtIdManOfTicket.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtIdManOfTicket, ex.Message);
                flagOk = false;
            }
            try
            {
                if (txtThreeNum.Text == "")
                    throw new Exception("שדה חובה");
                t.ThreeDigits = txtThreeNum.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtThreeNum, ex.Message);
                flagOk = false;
            }
           
            return flagOk;
        }
        bool flagCust;
        private bool CreateFieldsCust(Customers c)
        {
            flagCust = true;
            errorProvider1.Clear();
                try
                {
                    if (txtSumP.Text == "")
                        throw new Exception("שדה חובה");
                    cust.ChovCustomer -= Convert.ToInt32(txtSumP.Text);
                }
                catch (Exception ex)
                {
                    errorProvider1.SetError(txtSumP, ex.Message);
                    flagCust = false;
                }
            return flagCust;
        }
            private void rbAshray_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
        }

        private void rbMezuman_CheckedChanged_1(object sender, EventArgs e)
        {
           
            if (status== "customer")
            {
                cust.ChovCustomer -= Convert.ToDouble(txtSumP.Text);
                tblCust.UpdateRow(cust);
            }
            if (numericUpDown1.Value > 1)
            {
                MessageBox.Show("במזומן לא ניתן לשלם בכמה תשלומים");
                rbMezuman.Checked = false;
            }
            else
            {
                t = new Tashlumim();
                pt = new PratimOfTashlum();
                pt.NumTashlum = 1;
                pt.CodeTashlum = Convert.ToInt32(txtCode.Text);
                pt.SumForTashlum = Convert.ToInt32(txtSum.Text);
                t.CodeTashlum = Convert.ToInt32(txtCode.Text);
                t.IdCustomer = cust.ThisCustomers().IdCustomer;
                t.NumTashlumim = Convert.ToInt32(numericUpDown1.Value);
                t.SumOfAllTashlum = Convert.ToDouble(txtSum.Text);
                t.Date = dateTimePicker1.Value;
                t.OfenTshlum = "מזומן";
                tblT.AddNew(t);
                tblPt.AddNew(pt);
                MessageBox.Show("תודה שקניתם אצלנו");
                this.Close();
            }
            }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void frmTashlum_Load(object sender, EventArgs e)
        {

        }
    }
        }
   

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
    public partial class itemsBuying : Form
    {
        Buying b;
        BuyingDB tblBuying;
        string status;
        Mutsarim m;
        MutsarimDB tblMutsar;
        Customers cust;
        CustomersDB tblCust;
        MutsarimInTheBuying mlb;
        MutsarimInTheBuyingDB tblmlb;
        double sum;
        public itemsBuying(string ezer,int code,double sumAll,string id)
        {          
            InitializeComponent();
            panelW.Visible = false;
            status =ezer;
             sum = sumAll;
            b = new Buying();
            tblBuying = new BuyingDB();
            tblMutsar = new MutsarimDB();
            cust = new Customers();
            tblCust = new CustomersDB();
            tblmlb = new MutsarimInTheBuyingDB();
            dateTimePicker1.Value = DateTime.Now.Date;
            txtCodeBuying.Text =code.ToString();
            dataGridView1.DataSource = tblMutsar.GetList().Select(x => new
            {
                קוד_מוצר = x.CodeMutsar,
                תאור = x.Description,
                קטגוריה = x.ThisKategory().Description,
                חברה = x.ThisCompanies().NameCompany,
                מחיר_מכירה = x.PriceSell,
                כמות_מלאי = x.AmountMelay,
            }).ToList();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            if (rbW.Checked)
            {
              cust =tblCust.Find(txtId.Text);
            }
            if (rbGeneral.Checked)
            {
                cust = new Customers();
                cust = tblCust.Find("325995280");
                button5.Visible = false;
            }
                if (rbW.Checked||rbGeneral.Checked)
                {
                if (rbW.Checked&&txtNameCust.Text=="")
                    MessageBox.Show("יש למלא פרטים כנדרש");
                else
                {
                    b = new Buying();
                    b.CodeBuying = Convert.ToInt32(txtCodeBuying.Text);
                    b.IdCustomer =cust.IdCustomer;
                    b.DateBuying = Convert.ToDateTime(dateTimePicker1.Value);
                    b.SumOfAll = 0.0;
                    listView1.Visible = true;
                    tblBuying.AddNew(b);
                    panel1.Visible = true;
                }
                }
                else
                    MessageBox.Show("יש לבחור סוג לקוח");
        }
        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            panel2.Visible = true;
            Mutsarim m = tblMutsar.Find(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
            lblCode.Text = m.CodeMutsar.ToString();
            lblName.Text = m.Description.ToString();
            numericUpDown1.Value = 1;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (lblCode.Text == "")
                MessageBox.Show("בחר מוצר! בלחיצה כפולה על המוצר ברשימה");
            else
            { 
            m = tblMutsar.GetList().Find(x => x.CodeMutsar == Convert.ToInt32(lblCode.Text));
            sum = Convert.ToDouble(txtSum.Text);
                if (m != null)
                {
                    int amount = Convert.ToInt32(numericUpDown1.Value);
                    bool flag = true;
                    foreach (ListViewItem item1 in listView1.Items)
                    {
                        if (Convert.ToInt32(item1.SubItems[1].Text) == m.CodeMutsar)
                        {
                            DialogResult r = MessageBox.Show("המוצר כבר מופיע בהזמנה האם לעדכן כמות?", "", MessageBoxButtons.YesNo);
                            if (r == DialogResult.Yes)
                            {
                                amount += Convert.ToInt32(item1.SubItems[3].Text);
                                listView1.Items.Remove(item1);
                            }
                            else
                                flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        if (amount > m.AmountMelay)
                            MessageBox.Show("כמות המלאי הינה" + " " + m.AmountMelay + "\n" + "בחר כמות מתאימה");
                        else
                        {
                            double sumRow = m.PriceSell * amount;
                            //2 שורות הוספה ל-listview
                            ListViewItem lv = new ListViewItem(new string[] { txtCodeBuying.Text, m.CodeMutsar.ToString(), m.Description, amount.ToString(), m.PriceSell.ToString(), sumRow.ToString() });
                            listView1.Items.Add(lv);
                            sum += amount * m.PriceSell;
                            txtSum.Text = sum.ToString();
                        }
                    }
                    else
                        MessageBox.Show("בחר מוצר");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                double su = Convert.ToDouble(listView1.SelectedItems[0].SubItems[5].Text);
                sum -= su;
                txtSum.Text = sum.ToString();
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
            else
                MessageBox.Show("בחר מוצר לביטול");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtSum.Text == "0")
                MessageBox.Show("בחר מוצר");
            else 
            { 
                if (status == "חדש")
                {
                    foreach (ListViewItem item in listView1.Items)
                    {
                        mlb = new MutsarimInTheBuying();
                        mlb.CodeBuying = b.CodeBuying;
                        m = tblMutsar.Find(Convert.ToInt32(item.SubItems[1].Text));
                        mlb.CodeMutsar = m.CodeMutsar;
                        mlb.Amount = Convert.ToInt32(item.SubItems[3].Text);
                        mlb.SumForMutsar = Convert.ToDouble(item.SubItems[4].Text);
                       m.AmountMelay -= Convert.ToInt32(item.SubItems[3].Text);
                        tblmlb.AddNew(mlb);
                         tblMutsar.UpdateRow(m);
                    }
                }
                else
                {
                    foreach (ListViewItem item in listView1.Items)
                    {
                        mlb = new MutsarimInTheBuying();
                        mlb.CodeBuying = b.CodeBuying;
                        m = tblMutsar.Find(Convert.ToInt32(item.SubItems[1].Text));
                            if (tblmlb.Find(b.CodeBuying,m.CodeMutsar)!=null)
                                tblmlb.DeleteRow(b.CodeBuying, m.CodeMutsar);
                            mlb.CodeMutsar = m.CodeMutsar;
                        mlb.Amount = Convert.ToInt32(item.SubItems[3].Text);                    
                        mlb.SumForMutsar = Convert.ToDouble(item.SubItems[3].Text);
                        m.AmountMelay -= Convert.ToInt32(item.SubItems[4].Text);
                        tblmlb.UpdateRow(mlb);
                        tblMutsar.UpdateRow(m);
                    }
                }
                b.SumOfAll = sum;
                tblBuying.UpdateRow(b);
                txtSum.Text= sum.ToString();
                tblBuying.UpdateRow(b);
                frmTashlum t = new frmTashlum(sum,cust,"buying");
                    t.Show();
                this.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtSum.Text == "0")
                MessageBox.Show("בחר מוצר");
            else
            {
                if (status == "חדש")
                {
                    foreach (ListViewItem item in listView1.Items)
                    {
                        mlb = new MutsarimInTheBuying();
                        mlb.CodeBuying = b.CodeBuying;
                        m = tblMutsar.Find(Convert.ToInt32(item.SubItems[1].Text));
                        mlb.CodeMutsar = m.CodeMutsar;
                        mlb.Amount = Convert.ToInt32(item.SubItems[3].Text);
                        mlb.SumForMutsar = Convert.ToDouble(item.SubItems[4].Text);
                        m.AmountMelay -= Convert.ToInt32(item.SubItems[3].Text);
                        tblmlb.AddNew(mlb);
                        tblMutsar.UpdateRow(m);
                    }
                }
                else
                {
                    foreach (ListViewItem item in listView1.Items)
                    {
                        mlb = new MutsarimInTheBuying();
                        mlb.CodeBuying = b.CodeBuying;
                        m = tblMutsar.Find(Convert.ToInt32(item.SubItems[1].Text));
                        if (tblmlb.Find(b.CodeBuying, m.CodeMutsar) != null)
                            tblmlb.DeleteRow(b.CodeBuying, m.CodeMutsar);
                        mlb.CodeMutsar = m.CodeMutsar;
                        mlb.Amount = Convert.ToInt32(item.SubItems[3].Text);
                        mlb.SumForMutsar = Convert.ToDouble(item.SubItems[3].Text);
                        m.AmountMelay -= Convert.ToInt32(item.SubItems[4].Text);
                        tblmlb.UpdateRow(mlb);
                        tblMutsar.UpdateRow(m);
                    }
                }
                b.SumOfAll = sum;
                tblBuying.UpdateRow(b);
                txtSum.Text = sum.ToString();
                tblBuying.UpdateRow(b);
            }
            cust.ChovCustomer += Convert.ToDouble(txtSum.Text);
            tblCust.UpdateRow(cust);
            MessageBox.Show("תודה שקניתם אצלנו");
            this.Close();
        }

        private void rbW_CheckedChanged(object sender, EventArgs e)
        {
            panelW.Visible = true;
            label2.Visible = false;
            txtNameCust.Visible = false;
        }

        private void rbGeneral_CheckedChanged(object sender, EventArgs e)
        {
            panelW.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            cust = tblCust.Find(txtId.Text);
            if (cust == null)
                MessageBox.Show("יש לכתוב ת.ז. כנדרש");
            else
            {
                txtNameCust.Text = cust.FirstName + " " + cust.LastName;
                txtNameCust.Visible = true;
                label2.Visible = true;
                txtId.ReadOnly = true;
            }
        }
    }
    }


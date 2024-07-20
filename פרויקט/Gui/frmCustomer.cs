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
using פרויקט.Dal;
using פרויקט.Gui;
using פרויקט.Utilies;


namespace פרויקט.Gui
{
    
    public partial class frmCustomer : Form
    {
        Customers cust;
        CustomersDB tblCustomer;
        CitiesDB tblCity;
        public frmCustomer()
        {
            InitializeComponent();
            tblCustomer = new CustomersDB();
            tblCity = new CitiesDB();
            dataGridView1.DataSource = tblCustomer.GetList().Where(x => x.Status == true).Select(x => new { תעודת_זהות = x.IdCustomer,שם_פרטי=x.FirstName,שם_משפחה= x.LastName,רחוב=x
                .Street,עיר= x.ThisCities().NameOfCity,מספר_בית=x.NumOfHouse,חוב_לקוח=x.ChovCustomer }).ToList();
           comboBox1.DataSource=tblCity.GetList();
            NotPssible();
            comboBox1.SelectedIndex = -1;
        }
        bool flagAdd = true;
        bool flagUpdate = true;
        private void NotPssible()
        {
            flagAdd = false;
            flagUpdate = false;
            groupBox1.Visible =false;
            panel1.Visible = false;
            txtId.ReadOnly = true; 
            txtFirstName.ReadOnly = true;
            txtLastName.ReadOnly = true;
            txtStreet.ReadOnly = true;
            txtNumHouse.ReadOnly = true;
            comboBox1.SelectedIndex =-1;
        }
        private void Possible()
        {
            comboBox1.Enabled = true;
            groupBox1.Visible = true;
            panel1.Visible =true;
            txtId.ReadOnly =false;
            txtFirstName.ReadOnly = false;
            txtLastName.ReadOnly = false;
            txtStreet.ReadOnly =false;
            txtNumHouse.ReadOnly = false;
            panel2.Visible = false;
        }
        public void TextClear()
        {
            txtId.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtStreet.Text = "";
            comboBox1.Text ="";
            txtNumHouse.Text = "";
            txtChov.Text = "";
            comboBox1.SelectedIndex=-1;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            flagAdd= true;
            Possible();
            TextClear();
            button1.Visible = false;
            checkBox1.Checked = true;
            txtChov.Text = "0";
        }
        bool flagOk;
        private bool CreateFields(Customers c)
        {
            flagOk = true;
            errorProvider1.Clear();
            try
            {
                if (txtId.Text == "")
                    throw new Exception("שדה חובה");
               cust.IdCustomer=txtId.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtId, ex.Message);
                flagOk = false;
            }
            try
            {
                if (txtFirstName.Text == "")
                    throw new Exception("שדה חובה");
                cust.FirstName =txtFirstName.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtFirstName, ex.Message);
                flagOk = false;
            }
            try
            {
                if (txtLastName.Text == "")
                    throw new Exception("שדה חובה");
                cust.LastName = txtLastName.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtLastName, ex.Message);
                flagOk = false;
            }
            try
            {
                if (txtStreet.Text == "")
                    throw new Exception("שדה חובה");
                cust.Street = txtStreet.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtStreet, ex.Message);
                flagOk = false;
            }
            try
            {
                if (comboBox1.SelectedIndex > -1)
                    cust.City = ((Cities)comboBox1.SelectedItem).CodeCity;
                else
                {
                    MessageBox.Show("בחר עיר מהמאגר הקים");
                    flagOk = false;
                }
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(comboBox1, ex.Message);
                flagOk = false;
            }
            try
            {
                if (txtNumHouse.Text == "")
                    throw new Exception("שדה חובה");
                cust.NumOfHouse = txtNumHouse.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtNumHouse, ex.Message);
                flagOk = false;
            }

            //try
            //{
            //    if (txtChov.Text == "")
            //        throw new Exception("שדה חובה");
            //    cust.ChovCustomer = Convert.ToInt32(txtChov);
            //}
            //catch (Exception ex)
            //{
            //    errorProvider1.SetError(txtChov, ex.Message);
            //    flagOk = false;
            //}
            try
            {
                cust.Status =true;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(checkBox1, ex.Message);
                flagOk = false;
            }
            return flagOk;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string tz = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                cust = tblCustomer.Find(tz);
                DialogResult r = MessageBox.Show("אתה בטוח שברצונך למחוק לקוח זה ?", "אישור מחיקה", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    TextClear();
                    cust.Status = false;
                    tblCustomer.UpdateRow(cust);
                    dataGridView1.DataSource = tblCustomer.GetList().Where(x => x.Status == true).Select(x => new
                    {
                        תעודת_זהות = x.IdCustomer,
                        שם_פרטי = x.FirstName,
                        שם_משפחה = x.LastName,
                        רחוב = x
                .Street,
                        עיר = x.ThisCities().NameOfCity,
                        מספר_בית = x.NumOfHouse,
                        חוב_לקוח = x.ChovCustomer,
                    }).ToList();
                }
            }
            else
                MessageBox.Show("בחר שורה למחיקה");
        }

        private void btnRaanen_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = tblCustomer.GetList();
            TextClear();
            groupBox1.Visible = false;
            panel1.Visible = false;
           panel2.Visible = true;
            dataGridView1.DataSource = tblCustomer.GetList().Select(x => new {
                תעודת_זהות = x.IdCustomer,
                שם_פרטי = x.FirstName,
                שם_משפחה = x.LastName,
                רחוב = x
               .Street,
                עיר = x.ThisCities().NameOfCity,
                מספר_בית = x.NumOfHouse,
                חוב_לקוח = x.ChovCustomer,
                
            }).ToList();
        }
        private void Fill(Customers cust)
        {
            txtId.Text = cust.IdCustomer;
            txtFirstName.Text = cust.FirstName;
            txtLastName.Text = cust.LastName;
            txtStreet.Text = cust.Street;
            comboBox1.SelectedItem = cust.City;
            txtNumHouse.Text = cust.NumOfHouse;
            txtChov.Text = cust.ChovCustomer.ToString();
            checkBox1.Checked = cust.Status;
        }
        bool flag=true;
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (flagAdd)
            {
                cust = new Customers();
                //List<Customers> lst = tblCustomer.GetList().Where(x => x.Status == true).ToList();
                //foreach (Customers item in lst)
                //{
                //    if (item.IdCustomer == txtId.Text)
                //        flag = false;
                //}
                Customers c = tblCustomer.Find(txtId.Text);
                if (c != null)
                {
                    if(c.Status==true)
                   MessageBox.Show("הלקוח קים במערכת");
                   if(c.Status==false)
                    {
                        if (CreateFields(c))
                        {
                            DialogResult d = MessageBox.Show("האם להוסיף לקוח?", "אישור הוספה", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                            if (d == DialogResult.Yes)
                            {
                                tblCustomer.UpdateRow(c);
                                NotPssible();
                            }
                            TextClear();
                        }
                    }
                }
                    
                else
                {
                    if (CreateFields(cust))
                    {
                        DialogResult d = MessageBox.Show("האם להוסיף לקוח?", "אישור הוספה", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (d == DialogResult.Yes)
                        {
                            tblCustomer.AddNew(cust);
                            NotPssible();
                        }
                        TextClear();
                    }
                }
            }
            if (flagUpdate)
            {
                if (CreateFields(cust))
                {
                    DialogResult d = MessageBox.Show("האם לעדכן לקוח?", "אישור עדכון", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d == DialogResult.Yes)
                    {
                        tblCustomer.UpdateRow(cust);
                       NotPssible();
                    }
                    TextClear();
                }
            }
            dataGridView1.DataSource = tblCustomer.GetList().Select(x => new {
                תעודת_זהות = x.IdCustomer,
                שם_פרטי = x.FirstName,
                שם_משפחה = x.LastName,
                רחוב = x
               .Street,
                עיר = x.ThisCities().NameOfCity,
                מספר_בית = x.NumOfHouse,
                חוב_לקוח = x.ChovCustomer,
            }).ToList();
            panel2.Visible = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                groupBox1.Visible = true;
                Possible();
                txtChov.ReadOnly = false;
                string tz = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                cust = tblCustomer.Find(tz);
                Fill(cust);
                comboBox1.SelectedItem = cust.ThisCities().ToString();
                comboBox1.Text = cust.ThisCities().ToString();
                flagUpdate = true;
                flagAdd = false;
            }
            else
                MessageBox.Show("בחר שורה לעדכון");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            TextClear();
            panel1.Visible = false;
            panel2.Visible = true;
            groupBox1.Visible = false;
        }

        private void btnHatseg_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                cust = tblCustomer.Find(id);
                Fill(cust);
                groupBox1.Visible = true;
                panel1.Visible = true;
                panel2.Visible = true;
            }
            else
                MessageBox.Show("בחר שורה להצגה");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmTashlum fc = new frmTashlum(cust.ChovCustomer, cust,"customer");
            fc.Show();
        }
    }

    //private void btnRaanen_Click(object sender, EventArgs e)
    //    {
           
    //    }

    //    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    //    {
           

    //    }
    }


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
using פרויקט.Utilies;

namespace פרויקט.Gui
{
    public partial class frmCities : Form
    {
        CitiesDB tblCity;
        CustomersDB tblCustomer;
        public frmCities()
        {
            InitializeComponent();
            tblCity = new CitiesDB();
            dataGridViewCity.DataSource = tblCity.GetList().Select(x=>new { קוד=x.CodeCity,עיר=x.NameOfCity}).ToList();
            NotPossible();
        }
        Cities city;
        bool flagAdd = true;
        bool flagUpdate = true;
        private void NotPossible()
        {
            flagAdd = false;
            flagUpdate = false;
            gpCity.Visible =false;
            panelSaveCancel.Visible = false;
            textBox1.ReadOnly = true;
        }
        private void Possible()
        {
            
            textBox1.ReadOnly = false;
            panelSaveCancel.Visible = true;
            gpCity.Visible = true;
           
        }
        public void txtClear()
        {
           lblKod.Text = "";
            textBox1.Text = "";
        }
        private void ibiCodCity_Click(object sender, EventArgs e)
        {
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            flagAdd = true;
            Possible();
            txtClear();
            lblKod.Text = tblCity.GetNextKey().ToString();
            gpCity.Visible = true;
        }

        //private void comboNameCity_SelectedIndexChanged(object sender, EventArgs e)
        //{
        // lblKod.Text =tblCity.Find(comboNameCity.SelectedIndex).CodeCity.ToString();
        //  city = tblCity.Find(comboNameCity.SelectedIndex);
            
        //}

        private void lblNameCity_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (flagAdd)
            {
                city = new Cities();
                if (CreateFields(city))
                {
                    DialogResult d= MessageBox.Show("האם להוסיף עיר?", "אישור הוספה", MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button1);
                    if (d == DialogResult.Yes)
                    {
                        tblCity.AddNew(city);
                        NotPossible();
                      dataGridViewCity.DataSource = tblCity.GetList();
                    }
                }
            }
            if (flagUpdate)
            {
                if (CreateFields(city))
                {
                    DialogResult d = MessageBox.Show("האם לעדכן עיר?", "אישור עדכון", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d == DialogResult.Yes)
                    {
                        tblCity.UpdateRow(city);
                        NotPossible();
                      dataGridViewCity.DataSource = tblCity.GetList();
                    }
                }
            }
            txtClear();
        }
        bool fagOk;
        private bool CreateFields(Cities city)
        {
            fagOk = true;
            errorProvider1.Clear();
            try
            {
                if (textBox1.Text=="")
                    throw new Exception("שדה חובה");
                city.NameOfCity = textBox1.Text;
            }
            catch(Exception ex)
            {
                errorProvider1.SetError(textBox1, ex.Message);
                fagOk = false;
            }
            city.CodeCity =Convert.ToInt32( lblKod.Text);
            return fagOk;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewCity.SelectedRows.Count > 0)
            {
                gpCity.Visible = true;
                if (dataGridViewCity.SelectedRows.Count > 0)
                {
                    int codeCity = Convert.ToInt32(dataGridViewCity.SelectedRows[0].Cells[0].Value);
                    city = tblCity.Find(codeCity);
                    Fill(city);
                }
                flagUpdate = true;
                flagAdd = false;
                Possible();
            }
            else
                MessageBox.Show("בחר שורה לעדכון");
        }
        private void Fill(Cities city)
        {
            lblKod.Text = city.CodeCity.ToString();
            textBox1.Text = city.NameOfCity;
           textBox1.Text = city.NameOfCity;
            textBox1.Text = city.ThisCities().NameOfCity;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtClear();
            panelSaveCancel.Visible = false;
            gpCity.Visible = false;
            errorProvider1.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewCity.SelectedRows.Count > 0)
            {
               int kod =Convert.ToInt32( dataGridViewCity.SelectedRows[0].Cells[0].Value);
                city =tblCity.Find(Convert.ToInt32(kod));
                DialogResult r = MessageBox.Show("אתה בטוח שברצונך למחוק עיר זו ?", "אישור מחיקה", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(r==DialogResult.Yes)
                {

                   txtClear();

                   int code =Convert.ToInt32( dataGridViewCity.SelectedRows[0].Cells[0].Value);
                    tblCity.DeleteRow(code);
                    dataGridViewCity.DataSource = tblCity.GetList().Select(x => new { קוד = x.CodeCity, עיר = x.NameOfCity }).ToList();
                }

            }
        }

        private void btnRaanen_Click(object sender, EventArgs e)
        {
           dataGridViewCity.DataSource = null;
            dataGridViewCity.DataSource = tblCity.GetList().Select(x => new { קוד = x.CodeCity, עיר = x.NameOfCity }).ToList();
            txtClear();
          
           pnl.Visible = true;
        }

        private void btnHatseg_Click(object sender, EventArgs e)
        {
            if (dataGridViewCity.SelectedRows.Count > 0)
            {
                int code = Convert.ToInt32(dataGridViewCity.SelectedRows[0].Cells[0].Value);
                city = tblCity.Find(code);
                Fill(city);
                gpCity.Visible = true;

                pnl.Visible = true;
            }
            else
                MessageBox.Show("בחר עיר להצגה");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
    }

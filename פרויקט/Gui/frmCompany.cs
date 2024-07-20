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
    public partial class frmCompany : Form
    {
        CompaniesDB tblCompany;
        Companies company;
        bool flagAdd=true, flagUpdate=true;
        public frmCompany()
        {
            InitializeComponent();
            
            tblCompany = new CompaniesDB();
            dataGridView1.DataSource = tblCompany.GetList().Select(x=>new { קוד=x.Code,חברה=x.NameCompany}).ToList();
            NotPossible();
           
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            
           
        }
        private void Possible()
        {
            panel1.Visible = true;
            groupBox1.Visible = true;
            textBox1.ReadOnly = false;
            panel2.Visible = false;
        }

        private void NotPossible()
        {
            flagAdd = false;
            flagUpdate = false;
           
            panel1.Visible = false;
            textBox1.ReadOnly = true;
        }
        public void TextClear()
        {
            txtCode.Text = "";
            textBox1.Text = "";
        }
        bool flagOk;

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (flagAdd)
            {
                company = new Companies();
                if (CreateFields(company))
                {
                    DialogResult d = MessageBox.Show("האם להוסיף חברה?", "אישור הוספה", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (d == DialogResult.Yes)
                    {
                        tblCompany.AddNew(company);
                        NotPossible();
                         dataGridView1.DataSource =tblCompany.GetList();
                    }
                }
            }
            if (flagUpdate)
            {
                if (CreateFields(company))
                {
                    DialogResult d = MessageBox.Show("האם לעדכן חברה?", "אישור עדכון", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d == DialogResult.Yes)
                    {
                        tblCompany.UpdateRow(company);
                        NotPossible();
                        dataGridView1.DataSource =tblCompany.GetList();
                    }
                }
            }
        }
        private void Fill(Companies c)
        {
            txtCode.Text = company.Code.ToString();
            textBox1.Text = company.NameCompany;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            Possible();
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int codeC = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                company =tblCompany.Find(codeC);
                Fill(company);
            }
            flagUpdate = true;
            flagAdd = false;
            Possible();
        }

        private void cmbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
           txtCode.Text = tblCompany.Find(Convert.ToInt32( textBox1)).Code.ToString();
            company = tblCompany.Find(Convert.ToInt32( textBox1.Text));
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count>0)
            flagAdd = true;
            Possible();
            TextClear();
            txtCode.Text = tblCompany.GetNextKay().ToString();
            dataGridView1.DataSource = tblCompany.GetList().Select(x => new { קוד = x.Code, חברה = x.NameCompany }).ToList();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (flagAdd)
            {
                company = new Companies();
                if (CreateFields(company))
                {
                    DialogResult d = MessageBox.Show("האם להוסיף חברה?", "אישור הוספה", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (d == DialogResult.Yes)
                    {
                        tblCompany.AddNew(company);
                        NotPossible();
                    }
                }
            }
            if (flagUpdate)
            {
                if (CreateFields(company))
                {
                    DialogResult d = MessageBox.Show("האם לעדכן חברה?", "אישור עדכון", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d == DialogResult.Yes)
                    {
                        tblCompany.UpdateRow(company);
                        NotPossible();
                    }
                }
            }
            TextClear();
            dataGridView1.DataSource = tblCompany.GetList().Select(x => new { קוד = x.Code, חברה = x.NameCompany }).ToList();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            TextClear();
            panel1.Visible = false;
            panel2.Visible = true;
            groupBox1.Visible = false;
        }

        private void btnRaanen_Click(object sender, EventArgs e)
        {
           dataGridView1.DataSource = null;
            dataGridView1.DataSource = tblCompany.GetList();
           TextClear();
            groupBox1.Visible = true;
            panel1.Visible = true;
           panel2.Visible = true;
            dataGridView1.DataSource = tblCompany.GetList().Select(x => new { קוד = x.Code, חברה = x.NameCompany }).ToList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int kod = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                company = tblCompany.Find(kod);
                // company = tblCompany.Find(Convert.ToInt32(txtCode));
                DialogResult r = MessageBox.Show("אתה בטוח שברצונך למחוק חברה זו ?", "אישור מחיקה", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {

                    TextClear();

                    int code = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                    tblCompany.DeleteRow(code);
                    dataGridView1.DataSource = tblCompany.GetList().Select(x => new { קוד = x.Code, חברה = x.NameCompany }).ToList();
                }

            }
            else
                MessageBox.Show("בחר שורה למחיקה");
        }

        private void btnHtseg_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int code = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                company = tblCompany.Find(code);
                Fill(company);
                groupBox1.Visible = true;
                panel1.Visible = true;
                panel2.Visible = true;
            }
            else
                MessageBox.Show("בחר שורה להצגה");
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                groupBox1.Visible = true;
                Possible();
                int codeCity = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                company = tblCompany.Find(codeCity);
                Fill(company);
                flagUpdate = true;
                flagAdd = false;
            }
            else
                MessageBox.Show("בחר שורה לעדכון");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private bool CreateFields(Companies c)
        {
            flagOk= true;
            errorProvider1.Clear();
            try
            {
                if (textBox1.Text == "")
                    throw new Exception("שדה חובה");
                c.NameCompany = textBox1.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(textBox1, ex.Message);
               flagOk= false;
            }
            company.Code = Convert.ToInt32(txtCode.Text);
            return flagOk;
        }

    }
}

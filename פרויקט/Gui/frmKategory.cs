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

namespace פרויקט.Gui
{
    public partial class frmKategory : Form
    {
        KategoriesDB tblKategory;
        Kategories kategory;
       

        public frmKategory()
        {
            InitializeComponent();
            tblKategory = new KategoriesDB();
            
            dataGridView1.DataSource = tblKategory.GetList().Select(x=>new { קוד=x.Code,קטגוריה=x.Description}).ToList();
            NotPossible();
            
        }
        bool flagAdd=true;
        bool flagUpdate=true;
        private void NotPossible()
        {
            flagAdd = false;
            flagUpdate = false;
            groupBox1.Visible = false;
            panel1.Visible = false;
            textBox1.ReadOnly = true;
        }
        private void Possible()
        {
            groupBox1.Visible = true;
            panel1.Visible = true;
            textBox1.ReadOnly = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int code = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                kategory = tblKategory.Find(code);
                Fill(kategory);
               groupBox1.Visible = true;
               panel1.Visible = true;
                panel2.Visible = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (flagAdd)
            {
                kategory= new Kategories();
                if (CreateFields(kategory)) 
                {
                    DialogResult d = MessageBox.Show("האם להוסיף קטגוריה?", "אישור הוספה", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (d == DialogResult.Yes)
                    {
                        tblKategory.AddNew(kategory);
                        NotPossible();
                        dataGridView1.DataSource =tblKategory.GetList().Select(x=>new {קוד=x.Code,קטגוריה=x.Description }).ToList();
                    }
                }
            }
            if (flagUpdate)
            {
                if (CreateFields(kategory))
                {
                    DialogResult d = MessageBox.Show("האם לעדכן קטגוריה?", "אישור עדכון", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d == DialogResult.Yes)
                    {
                        tblKategory.UpdateRow(kategory);
                        NotPossible();
                        dataGridView1.DataSource =tblKategory.GetList().Select(x => new { קוד = x.Code, קטגוריה = x.Description }).ToList ();
                    }
                }
            }
            ClearText();
        }
        private void Fill(Kategories kat)
        {
            txtKod.Text = kat.Code.ToString();
            textBox1.Text = kat.Description;
        }

        private void cmbKategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtKod.Text = tblKategory.Find(Convert.ToInt32( textBox1.Text)).Code.ToString();
            kategory=tblKategory.Find(Convert.ToInt32( textBox1));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            flagAdd = true;
            Possible();
            ClearText();
           
         txtKod.Text = tblKategory.GetNextKay().ToString();
            dataGridView1.DataSource = tblKategory.GetList().Select(x => new { קוד = x.Code, קטגוריה = x.Description }).ToList();
        }
        bool flagOk;
        private bool CreateFields(Kategories kat)
        {
            flagOk = true;
            errorProvider1.Clear();
            try
            {
                if (txtKod.Text == "")
                    throw new Exception("שדה חובה");
               kategory.Description=textBox1.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(textBox1, ex.Message);
                flagOk = false;
            }
            kategory.Code = Convert.ToInt32(txtKod.Text);
            return flagOk;
        }

        public void ClearText()
        {
            txtKod.Text = "";
            textBox1.Text= "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            Possible();
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int codeK = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
               kategory =tblKategory.Find(codeK);
                Fill(kategory);
            }
            flagUpdate = true;
            flagAdd = false;
            Possible();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearText();
            panel1.Visible = false;
            groupBox1.Visible = false;
        }

        private void btnRaanen_Click(object sender, EventArgs e)
        {
           dataGridView1.DataSource = null;
            dataGridView1.DataSource = tblKategory.GetList().Select(x => new { קוד = x.Code, קטגוריה = x.Description }).ToList();
            ClearText();
            groupBox1.Visible = true;
           panel1.Visible = true;
            panel2.Visible = true;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int kod = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
              
                kategory = tblKategory.Find(kod);
                DialogResult r = MessageBox.Show("אתה בטוח שברצונך למחוק קטגוריה זו ?", "אישור מחיקה", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(r==DialogResult.Yes)
                {

                   ClearText();

                    int code = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                    tblKategory.DeleteRow(code);
                    dataGridView1.DataSource = tblKategory.GetList().Select(x => new { קוד = x.Code, קטגוריה = x.Description }).ToList();
                }
                
            }
        }

        private void frmKategory_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

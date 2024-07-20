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
    public partial class frmSapak : Form
    {
        Sapaks s;
        SapaksDB tblSapak;
        bool flagUpdate, flagAdd;

        public frmSapak()
        {
            InitializeComponent();
            tblSapak = new SapaksDB();
            dataGridView1.DataSource = tblSapak.GetList().Where(x=>x.Status=true).Select(x => new { קוד = x.CodeSapak, ספק = x.NameOfSapak }).ToList();
            NotPossible();
        }
        private void NotPossible()
        {
            groupBox1.Visible = false;
            flagAdd = false;
            flagUpdate = false;
            panel2.Visible = true;
            panel1.Visible = false;
            txtCode.ReadOnly = true;
            txtName.ReadOnly = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            flagAdd = true;
            Possible();
            ClearText();

            txtCode.Text = Convert.ToInt32(tblSapak.GetNextKey()).ToString();
            dataGridView1.DataSource = tblSapak.GetList().Where(x => x.Status = true).Select(x => new {
                קוד = x.CodeSapak,
                ספק = x.NameOfSapak
            }).ToList();
        }

        private void Possible()
        {
            groupBox1.Visible = true;
            panel2.Visible = false;
            panel1.Visible = true;
            txtCode.ReadOnly = false;
            txtName.ReadOnly = false;
        }
        private void ClearText()
        {
            txtCode.Text = "";
            txtName.Text = "";
        }
        bool flagOk;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (flagAdd)
            {
                s = new Sapaks();
                if (CreateFields(s))
                {
                    DialogResult d = MessageBox.Show("האם להוסיף ספק?", "אישור הוספה", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (d == DialogResult.Yes)
                    {
                        tblSapak.AddNew(s);
                        NotPossible();
                    }
                }
            }
            if (flagUpdate)
            {
                if (CreateFields(s))
                {
                    DialogResult d = MessageBox.Show("האם לעדכן ספק?", "אישור עדכון", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d == DialogResult.Yes)
                    {
                        tblSapak.UpdateRow(s);
                        NotPossible();
                    }
                }
            }
            dataGridView1.DataSource = tblSapak.GetList();
        }

        private void btnRaanen_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = tblSapak.GetList().Where(x => x.Status = true).Select(x => new { קוד = x.CodeSapak, ספק = x.NameOfSapak }).ToList();
            ClearText();
            groupBox1.Visible = true;
            panel1.Visible = true;
            panel2.Visible = true;
        }
        private void Fill(Sapaks s)
        {
            txtCode.Text = s.CodeSapak.ToString();
            txtName.Text = s.NameOfSapak;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            Possible();
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int code = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                s = tblSapak.Find(code);
                Fill(s);
            }
            flagUpdate = true;
            flagAdd = false;
            Possible();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearText();
            panel1.Visible = false;
            panel2.Visible = true;
            groupBox1.Visible = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int kod = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

                s = tblSapak.Find(kod);
                DialogResult r = MessageBox.Show("אתה בטוח שברצונך למחוק ספק זה ?", "אישור מחיקה", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {

                    ClearText();
                    s.Status = false;
                    tblSapak.UpdateRow(s);
                    dataGridView1.DataSource = tblSapak.GetList().Where(x => x.Status = true).Select(x => new { קוד = x.CodeSapak, ספק = x.NameOfSapak }).ToList();
                }
                

            }
        }

        private void btnHatseg_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int code = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                s = tblSapak.Find(code);
                Fill(s);
                groupBox1.Visible = true;
                panel1.Visible = true;
                panel2.Visible = true;
            }
        }

        private bool CreateFields(Sapaks s)
        {
            flagOk = true;
            errorProvider1.Clear();
            s.Status = true;
            try
            {
                if (txtCode.Text == "")
                    throw new Exception("שדה חובה");
                s.CodeSapak =Convert.ToInt32( txtCode.Text);
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtCode, ex.Message);
                flagOk = false;
            }
            s.CodeSapak =Convert.ToInt32( txtCode.Text);
            try
            {
                if (txtName.Text == "")
                    throw new Exception("שדה חובה");
                s.NameOfSapak =txtName.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtName, ex.Message);
                flagOk = false;
            }
            s.NameOfSapak =txtName.Text;
            return flagOk;
        }

    }
}

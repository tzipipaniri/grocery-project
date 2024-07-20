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
    public partial class frmMutsar : Form
    {
        bool flagAdd = true, flagUpdate = true;
        Mutsarim mutsar;
        MutsarimDB tblMutsar;
        KategoriesDB tblKategory;
        CompaniesDB tblCompany;
        public frmMutsar()
        {
            InitializeComponent();
            tblKategory = new KategoriesDB();
            tblCompany = new CompaniesDB();
            tblMutsar = new MutsarimDB();
            dataGridView1.DataSource = tblMutsar.GetList().Where(x=>x.Status=true).Select(x => new {
                קוד = x.CodeMutsar,
                קטגוריה = x.ThisKategory().Description,
                חברה = x.ThisCompanies().NameCompany,
                מחיר_קניה = x.PriceBuying,
                מחיר_מכירה = x.PriceSell,
                כמות_מלאי = x.AmountMelay,
                תאור = x.Description
            }).ToList();
            NotPossible();
            comboBox1.DataSource = tblKategory.GetList();
            cmbCompany.DataSource = tblCompany.GetList();
            comboBox1.SelectedIndex = -1;
            cmbCompany.SelectedIndex = -1;
        }
        private void NotPossible()
        {
            flagAdd = false;
            flagUpdate = false;
            groupBox1.Visible = false;
            panel2.Visible = true;
            panel1.Visible = false;            
            comboBox1.SelectedIndex =-1;
            cmbCompany.SelectedIndex =-1;
            txtPBuy.ReadOnly = true;
            txtPS.ReadOnly = true;
            txtAmountM.ReadOnly = true;
            txtDescr.ReadOnly = true;
        }
        private void Possible()
        {
            groupBox1.Visible = true;
            panel2.Visible = false;
            panel1.Visible = true;
            txtCode.ReadOnly = false;
            comboBox1.Enabled = true;
            cmbCompany.Enabled = true;
            txtPBuy.ReadOnly = false;
            txtPS.ReadOnly = false;
            txtAmountM.ReadOnly = false;
            txtDescr.ReadOnly = false;
        }
        public void TextClear()
        {
            txtCode.Text = "";
            comboBox1.SelectedIndex = -1;
            cmbCompany.SelectedIndex = -1;
            txtPBuy.Text = "";
            txtPS.Text = "";
            txtAmountM.Text = "";
            txtDescr.Text = "";
        }
        bool flagOk;

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (flagAdd)
            {
                mutsar = new Mutsarim();
                if (CreateFields(mutsar))
                {
                    DialogResult d = MessageBox.Show("האם להוסיף מוצר?", "אישור הוספה", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (d == DialogResult.Yes)
                    {
                        tblMutsar.AddNew(mutsar);
                        NotPossible();
                    }
                }
            }
            if (flagUpdate)
            {
                if (CreateFields(mutsar))
                {
                    DialogResult d = MessageBox.Show("האם לעדכן מוצר?", "אישור עדכון", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d == DialogResult.Yes)
                    {
                        tblMutsar.UpdateRow(mutsar);
                        NotPossible();
                    }
                }
            }
                dataGridView1.DataSource = tblMutsar.GetList().Where(x=>x.Status=true).Select(x => new {
                    קוד = x.CodeMutsar,
                    קטגוריה = x.ThisKategory().Description,
                    חברה = x.ThisCompanies().NameCompany,
                    מחיר_קניה = x.PriceBuying,
                    מחיר_מכירה = x.PriceSell,
                    כמות_מלאי = x.AmountMelay,
                    תאור = x.Description
                }).ToList();

        }

        private void btnRaanen_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = tblMutsar.GetList().Where(x=>x.Status=true).Select(x => new { קוד = x.CodeMutsar, קטגוריה = x.ThisKategory().Description,
                חברה=x.ThisCompanies().NameCompany,מחיר_קניה=x.PriceBuying,מחיר_מכירה=x.PriceSell,כמות_מלאי=x.AmountMelay,תאור=x.Description }).ToList();
            TextClear();
            groupBox1.Visible = true;
            panel1.Visible = true;
            panel2.Visible = true;

        }
        private void Fill(Mutsarim m)
        {
            txtCode.Text = m.CodeMutsar.ToString();
            comboBox1.SelectedItem = m.ThisKategory();
            comboBox1.Text = m.ThisKategory().ToString();
            //cmbCompany.Text = m.Company;
            txtPBuy.Text = m.PriceBuying.ToString();
            txtPS.Text = m.PriceSell.ToString();
            txtAmountM.Text = m.AmountMelay.ToString();
            txtDescr.Text = m.Description;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int code =Convert.ToInt32( dataGridView1.SelectedRows[0].Cells[0].Value);
                mutsar = tblMutsar.Find(code);
                Fill(mutsar);
                comboBox1.SelectedItem = mutsar.ThisKategory().ToString();
                comboBox1.Text = mutsar.ThisKategory().ToString();
                cmbCompany.SelectedItem = mutsar.ThisCompanies().ToString();
                cmbCompany.Text = mutsar.ThisCompanies().ToString();
            }
            flagUpdate = true;
            flagAdd = false;
            Possible();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            TextClear();
            panel1.Visible = false;
            panel2.Visible = true;
            groupBox1.Visible = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            flagAdd = true;
            Possible();
            TextClear();
            txtCode.Text =Convert.ToInt32( tblMutsar.GetNextKey()).ToString();
            dataGridView1.DataSource = tblMutsar.GetList().Where(x => x.Status = true).Select(x => new {
                קוד = x.CodeMutsar,
                קטגוריה = x.ThisKategory().Description,
                חברה = x.ThisCompanies().NameCompany,
                מחיר_קניה = x.PriceBuying,
                מחיר_מכירה = x.PriceSell,
                כמות_מלאי = x.AmountMelay,
                תאור = x.Description
            }).ToList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int kod = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

                mutsar = tblMutsar.Find(kod);
                DialogResult r = MessageBox.Show("אתה בטוח שברצונך למחוק מוצר זה ?", "אישור מחיקה", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {

                    TextClear();
                    mutsar.Status = false;
                    tblMutsar.UpdateRow(mutsar);
                    dataGridView1.DataSource = tblMutsar.GetList().Where(x => x.Status = true).Select(x => new {
                        קוד = x.CodeMutsar,
                        קטגוריה = x.ThisKategory().Description,
                        חברה = x.ThisCompanies().NameCompany,
                        מחיר_קניה = x.PriceBuying,
                        מחיר_מכירה = x.PriceSell,
                        כמות_מלאי = x.AmountMelay,
                        תאור = x.Description
                    }).ToList();
                }
               
            }
        }

        private void btnHatseg_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int code = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                mutsar = tblMutsar.Find(code);
                Fill(mutsar);
                groupBox1.Visible = true;
                panel1.Visible = true;
                panel2.Visible = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.DataSource = tblKategory.GetList();
        }

        private void cmbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private bool CreateFields(Mutsarim mutsar)
            {
                flagOk = true;
                errorProvider1.Clear();
                try
                {
                    if (txtCode.Text == "")
                        throw new Exception("שדה חובה");
                    mutsar.CodeMutsar =Convert.ToInt32( txtCode.Text);
                }
                catch (Exception ex)
                {
                    errorProvider1.SetError(txtCode, ex.Message);
                    flagOk = false;
                }

            try
            {
                if (comboBox1.SelectedIndex > -1)
                    mutsar.Kategory = ((Kategories)comboBox1.SelectedItem).Code;
                else
                {
                    MessageBox.Show("בחר קטגוריה מהמאגר הקים");
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
                if (cmbCompany.SelectedIndex > -1)
                    mutsar.Company = ((Companies)cmbCompany.SelectedItem).Code;
                else
                {
                    MessageBox.Show("בחר חברה מהמאגר הקים");
                    flagOk = false;
                }
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(cmbCompany, ex.Message);
                flagOk = false;
            }

            try
                {
                    if (txtPBuy.Text == "")
                        throw new Exception("שדה חובה");
                    mutsar.PriceBuying = Convert.ToDouble(txtPBuy.Text);
                }
                catch (Exception ex)
                {
                    errorProvider1.SetError(txtPBuy, ex.Message);
                    flagOk = false;
                }
               
                try
                {
                    if (txtPS.Text == "")
                        throw new Exception("שדה חובה");
                    mutsar.PriceSell = Convert.ToDouble(txtPS.Text);
                }
                catch (Exception ex)
                {
                    errorProvider1.SetError(txtPS, ex.Message);
                    flagOk = false;
                }
                
                try
                {
                    if (txtAmountM.Text == "")
                        throw new Exception("שדה חובה");
                    mutsar.AmountMelay = Convert.ToInt32(txtAmountM.Text);
                }
                catch (Exception ex)
                {
                    errorProvider1.SetError(txtAmountM, ex.Message);
                    flagOk = false;
                }
              
                try
                {
                    if (txtDescr.Text == "")
                        throw new Exception("שדה חובה");
                    mutsar.Description = txtDescr.Text;
                }
                catch (Exception ex)
                {
                    errorProvider1.SetError(txtDescr, ex.Message);
                    flagOk = false;
                }
            mutsar.Status = true;
           
                return flagOk;
            }
        }
    }


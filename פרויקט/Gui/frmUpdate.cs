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
    public partial class frmUpdate : Form
    {
        MutsarimInTheRechisha mlr; 
        MutsarimInTheRechishaDB tblMLR;
        MutsarimDB tblMutsar;
        Mutsarim m;
        Rechishas r;
        RechishasDB tblr;
        int codeR;
        public frmUpdate(int c)
        {
            codeR = c;
            r = new Rechishas();
            tblr = new RechishasDB();
            InitializeComponent();
            lblGet.Visible = false;
            numericUpDown1.Visible = false;
            tblMLR = new MutsarimInTheRechishaDB();
            dataGridView1.DataSource = tblMLR.GetList().Where(x => x.CodeRechisha == c).Select(x => new {קוד_רכישה=x.CodeRechisha,קוד_מוצר=x.CodeMutsar,תאור=x.ThisMutsar().Description 
           , כמות_הזמנה=x.AmountInvatition,כמות_מתקבלת=x.AmountMitkabelet,מחיר_למוצר=x.PriceForMutsar,סהכ=x.AmountInvatition*x.PriceForMutsar}).ToList();
            tblMutsar = new MutsarimDB();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            int get = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[4].Value);
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[3].Value);
                // numericUpDown1.Maximum = id;
                if (numericUpDown1.Value > id)
                {
                    DialogResult re = MessageBox.Show("הכמות שהזנת גדולה מהכמות המוזמנת, האם ברצונך להמשיך?", "", MessageBoxButtons.YesNo);
                    if (re == DialogResult.Yes)
                    {
                        UpdateReturn(get);
                    }
                }
                else
                    UpdateReturn(get);
                
            }
            else
                MessageBox.Show("בחר מוצר לעדכון");
            if (r.Status)
            {
                MessageBox.Show("שלום ולהתראות");
                this.Close();
            }
            tblMLR.UpdateRow(mlr);
            tblr.UpdateRow(r);
        }

        private void UpdateReturn(int g)
        {
            mlr = tblMLR.Find(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value), Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[1].Value));
            mlr.AmountMitkabelet = Convert.ToInt32(numericUpDown1.Value)+g;
            tblMLR.UpdateRow(mlr);
            r = tblr.Find(codeR);
            m = tblMutsar.Find(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[1].Value));
            m.AmountMelay += Convert.ToInt32(numericUpDown1.Value);
            tblMutsar.UpdateRow(m);
            dataGridView1.DataSource = tblMLR.GetList().Where(x => x.CodeRechisha == r.CodeRechisha && x.AmountMitkabelet<x.AmountInvatition).Select(x => new
            {
                קוד_רכישה = x.CodeRechisha,
                קוד_מוצר = x.CodeMutsar,
                תאור = x.ThisMutsar().Description
,
                כמות_הזמנה = x.AmountInvatition,
                כמות_מתקבלת = x.AmountMitkabelet,
                מחיר_למוצר = x.PriceForMutsar,
                סהכ = x.AmountInvatition * x.PriceForMutsar
            }).ToList();

            //List<MutsarimInTheRechisha> lst = tblMLR.GetList().Where(x => x.CodeRechisha ==codeR).ToList();
            //cmbCodeS.SelectedItem = tblS.GetList().Where(x => x.CodeSapak == codeS).Select(x => x.NameOfSapak);
            //cmbCodeS.Enabled = false;
            List<MutsarimInTheRechisha> lst = tblMLR.GetList().Where(x => x.CodeRechisha == codeR).ToList();
            int numMutsar = lst.Count();
            foreach (MutsarimInTheRechisha item in lst)
            {
                if (item.AmountInvatition <= item.AmountMitkabelet)
                {
                    numMutsar--;
                    tblMLR.DeleteRow(mlr.CodeRechisha, mlr.CodeMutsar);
                }
                   
            }
            if (numMutsar == 0)
                r.Status = true;
            tblr.UpdateRow(r);
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            lblGet.Visible = true;
            numericUpDown1.Visible = true;
            numericUpDown1.Value = 1;
            numericUpDown1.Maximum = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[3].Value);
        }
    }
    }


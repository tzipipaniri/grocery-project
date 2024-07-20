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
    public partial class frmRechishaFromSapak : Form
    {
        Rechishas r;
        RechishasDB tblRechisha;
        public frmRechishaFromSapak()
        {
            InitializeComponent();            
            tblRechisha = new RechishasDB();
            textBox1.Text = DateTime.Now.ToString();
            dataGridView1.DataSource = tblRechisha.GetList().Where(x=>x.Status==false).Select(x => new
            {
                קוד_רכישה = x.CodeRechisha,
                קוד_ספק = x.CodeSapak,
                תאריך_הזמנה = x.DateInvaitition,
                סך_הכל_רכישה = x.SachHacolRechisha,
                תאריך_קבלת_סחורה = x.DateGetingSchora
            }).ToList();
            groupBox1.Visible = false;
        }
        private void NewUpdate()
        {

        }

        private void btnRaanen_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = tblRechisha.GetList().Where(x=>x.Status==false).Select(x => new {
                קוד_רכישה = x.CodeRechisha,
                קוד_ספק = x.CodeSapak,
                תאריך_הזמנה = x.DateInvaitition,
                סך_הכל_רכישה = x.SachHacolRechisha,
                תאריך_קבלת_סחורה = x.DateGetingSchora
            }).ToList();
          
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int kod = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                int codeS= Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[1].Value);
                r = tblRechisha.Find(kod);
                DialogResult d = MessageBox.Show("אתה בטוח שברצונך למחוק רכישה זו ?", "אישור מחיקה", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    int code = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                    tblRechisha.DeleteRow(code);
                    dataGridView1.DataSource = tblRechisha.GetList().Where(x=>x.Status==false).Select(x => new {
                        קוד_רכישה = x.CodeRechisha,
                        קוד_ספק = x.CodeSapak,
                        תאריך_הזמנה = x.DateInvaitition,
                        סך_הכל_רכישה = x.SachHacolRechisha,
                        תאריך_קבלת_סחורה = x.DateGetingSchora
                    }).ToList();
                }

            }
        }

        private void btnHatseg_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int code = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                int codeS= Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[1].Value);
                r = tblRechisha.Find(code);
            }
        }
        string str = "";
        private void btnNew_Click(object sender, EventArgs e)
        {
            str = "חדש";
            frmItemsRechisha frm= new frmItemsRechisha(tblRechisha.GetNextKey(),str,0);
            frm.Show();
            this.Close();
        }

        private void btmUpdate_Click(object sender, EventArgs e)
        {
            //str = "עדכן";
            //frmItemsRechisha frm = new frmItemsRechisha(Convert.ToInt32( dataGridView1.SelectedRows[0].Cells[0].Value), str, Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[1].Value));
            //frm.Show();
            //this.Close();
            DialogResult d = MessageBox.Show("אתה בטוח שברצונך למחוק הזמנה זו ?", "אישור מחיקה", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                r = tblRechisha.Find(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                r.Status = true;
                tblRechisha.UpdateRow(r);
            }
            dataGridView1.DataSource = tblRechisha.GetList().Where(x => x.Status == false).Select(x => new {
                קוד_רכישה = x.CodeRechisha,
                קוד_ספק = x.CodeSapak,
                תאריך_הזמנה = x.DateInvaitition,
                סך_הכל_רכישה = x.SachHacolRechisha,
                תאריך_קבלת_סחורה = x.DateGetingSchora
            }).ToList();
        }

        private void btnAsher_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int c = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                frmUpdate u = new frmUpdate(c);
                u.ShowDialog();
                dataGridView1.DataSource = tblRechisha.GetList().Where(x => x.Status == false).Select(x => new
                {
                    קוד_רכישה = x.CodeRechisha,
                    קוד_ספק = x.CodeSapak,
                    תאריך_הזמנה = x.DateInvaitition,
                    סך_הכל_רכישה = x.SachHacolRechisha,
                    תאריך_קבלת_סחורה = x.DateGetingSchora
                }).ToList();
            }
            else
                MessageBox.Show("בחר הזמנה לעדכון");
            this.Close();
        }
        private void Fill(Rechishas r)
        {
            txtCodeR.Text = r.CodeRechisha.ToString();
            txtCodeS.Text = r.CodeSapak.ToString();
            textBox1.Text =Convert.ToDateTime( r.DateInvaitition).Date.ToString();
            txtSach.Text = r.SachHacolRechisha.ToString();
            textBox2.Text = Convert.ToDateTime(r.DateGetingSchora).Date.ToString();
        }

        private void btnHatseg_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int code = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                r = tblRechisha.Find(code);
                Fill(r);
                groupBox1.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = tblRechisha.GetList().Where(x=>x.Status==false).Select(x => new
            {
                קוד_רכישה = x.CodeRechisha,
                קוד_ספק = x.CodeSapak,
                תאריך_הזמנה = x.DateInvaitition,
                סך_הכל_רכישה = x.SachHacolRechisha,
                תאריך_קבלת_סחורה = x.DateGetingSchora
            }).ToList();
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            groupBox1.Visible = false;
        }
    }
    }

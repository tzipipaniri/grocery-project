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
    public partial class frmItemsRechisha : Form
    {
        Rechishas r;
        RechishasDB tblR;
        Mutsarim m;
        MutsarimDB tblM;
        Sapaks s;
        SapaksDB tblS;
        MutsarimInTheRechisha mlr;
        MutsarimInTheRechishaDB tvlmlr;
        string status;
        double sum ;
        public frmItemsRechisha(int c,string str,int codeS)
        {
            InitializeComponent();
            dtpInvit.Enabled = false;
            status = str;
            double sum=0 ;
            r = new Rechishas();
            tblR = new RechishasDB();
            tblM = new MutsarimDB();
            s = new Sapaks();
            tblS = new SapaksDB();
            tvlmlr = new MutsarimInTheRechishaDB();
            txtCodeR.Text =c.ToString();
            dataGridView1.DataSource = tblM.GetList().Select(x => new
            {
                קוד_מוצר = x.CodeMutsar,
                תאור = x.Description,
                קטגוריה = x.ThisKategory().Description,
                חברה = x.ThisCompanies().NameCompany,
                מחיר_קניה = x.PriceBuying,
                כמות_מלאי = x.AmountMelay
            }).ToList();
            cmbCodeS.DataSource = tblS.GetList();
            cmbCodeS.SelectedIndex = -1;
            if (str == "עדכן")
            {
                dtpGet.Enabled = false;
                btnIshur.Visible = false;
                listView1.Visible = true;
                panel1.Visible = true;
                Rechishas r = tblR.Find(c);
                // הבאות)מילוי כומבובוקס (2 השורות
                cmbCodeS.SelectedItem = r.ThisSapak().ToString();
                cmbCodeS.Text = r.ThisSapak().ToString();
                //cmbCodeS.Enabled = false;
                dtpInvit.Value = Convert.ToDateTime( r.DateInvaitition);
               dtpGet.Value= Convert.ToDateTime(r.DateGetingSchora);
                List<MutsarimInTheRechisha> lst=tvlmlr.GetList().Where(x => x.CodeRechisha == Convert.ToInt32(txtCodeR.Text)).ToList();
                cmbCodeS.SelectedItem = tblS.GetList().Where(x => x.CodeSapak == codeS).Select(x => x.NameOfSapak);
                cmbCodeS.Enabled = false;
                foreach (MutsarimInTheRechisha item1 in lst)
                {
                    ListViewItem lv = new ListViewItem(new string[] { txtCodeR.Text, item1.CodeMutsar.ToString(), item1.ThisMutsar().Description,item1.AmountInvatition.ToString(),item1.PriceForMutsar.ToString(),(item1.PriceForMutsar*item1.AmountInvatition).ToString()});
                    listView1.Items.Add(lv);
                    sum+=Convert.ToDouble( item1.PriceForMutsar * item1.AmountInvatition);
                }
                txtSach.Text = sum.ToString();
                dtpGet.MinDate = dtpInvit.Value ;
                dtpInvit.Enabled = false;
            }
            else if(str=="חדש")
            {
                // dtpInvit.MinDate == DateTime.Now.Date;
                dtpInvit.Value = DateTime.Now.Date;
            }
        }
        private void btnIshur_Click(object sender, EventArgs e)
        {
            if (cmbCodeS.Text != "" && dtpInvit.Value.ToString()!= "" && txtSach.Text != "" && dtpGet.Value .ToString()!= "")
            {
                r = new Rechishas();
                r.CodeRechisha = Convert.ToInt32(txtCodeR.Text);
                r.CodeSapak = Convert.ToInt32(cmbCodeS.Text);
                r.DateInvaitition = Convert.ToDateTime(dtpInvit.Value);
                r.SachHacolRechisha = Convert.ToDouble(txtSach.Text);
                r.DateGetingSchora = Convert.ToDateTime(dtpGet.Value);
                r.Status = false;
                txtCodeR.Text = tvlmlr.GetNextKey().ToString();
            }
        }
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            m=tblM.GetList().Find(x => x.CodeMutsar ==Convert.ToInt32( lblCode.Text));
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
                        //2 שורות הוספה ל-listview
                        ListViewItem lv = new ListViewItem(new string[] { txtCodeR.Text, m.CodeMutsar.ToString(), m.Description, amount.ToString(), m.PriceBuying.ToString(), (m.PriceBuying * amount).ToString() });
                        listView1.Items.Add(lv);
                        double sum2 = amount * m.ThisMutsar().PriceBuying;
                        sum += sum2;
                        txtSach.Text = sum.ToString();
                    }
                }
                else
                    MessageBox.Show("בחר מוצר");
            }
        }
        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Mutsarim m = tblM.Find(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["קוד_רכישה"].Value));
            lblCode.Text = m.CodeMutsar.ToString();
            lblName.Text = m.Description.ToString();
            numericUpDown1.Value = 1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (status == "חדש")
            {
                foreach (ListViewItem item1 in listView1.Items)
                {
                    MutsarimInTheRechisha ml = new MutsarimInTheRechisha();
                    ml.CodeRechisha = r.CodeRechisha;
                    ml.CodeMutsar = Convert.ToInt32(item1.SubItems[0]);
                    ml.AmountInvatition = Convert.ToInt32(item1.SubItems[2]);
                    ml.PriceForMutsar = Convert.ToDouble(item1.SubItems[4].Text);
                    tvlmlr.AddNew(ml);
                    //עדכון מחיר סופי להזמנה
                    r.SachHacolRechisha += sum;
                    tblR.UpdateRow(r);
                }
            }
            if (status == "עדכן")
            {
                MutsarimInTheRechisha ml = tvlmlr.GetList().Find(x => x.CodeRechisha == Convert.ToInt32(txtCodeR.Text));
                double sum2 = r.SachHacolRechisha;
                sum = Convert.ToInt32(txtSach.Text);
                foreach (ListViewItem item1 in listView1.Items)
                {
                    int mutsar = ml.AmountInvatition;
                    ml = tvlmlr.Find(r.CodeRechisha, Convert.ToInt32(item1.SubItems[1]));
                    ml.AmountInvatition = Convert.ToInt32(item1.SubItems[2]);
                    ml.PriceForMutsar = Convert.ToDouble(item1.SubItems[4].Text);
                    tvlmlr.UpdateRow(ml);
                }
                r.SachHacolRechisha = Convert.ToInt32(txtSach.Text);
                tblR.UpdateRow(r);
            }
            MessageBox.Show("שלום ולהתראות" + " " + "אישור");
            this.Close();
        }
        private void btnIshur_Click_1(object sender, EventArgs e)
     {
           
            if (status == "חדש")
            {
                if (cmbCodeS.SelectedIndex > -1 && dtpInvit.Value.ToString() != "" && dtpGet.Value.ToString() != "")
                {
                    r = new Rechishas();
                    r.CodeRechisha = Convert.ToInt32(txtCodeR.Text);
                    r.CodeSapak = ((Sapaks)cmbCodeS.SelectedItem).CodeSapak;
                    r.DateInvaitition = Convert.ToDateTime(dtpInvit.Value);
                    r.SachHacolRechisha = 0.0;
                    r.DateGetingSchora = Convert.ToDateTime(dtpGet.Value);
                    r.Status = false;
                    tblR.AddNew(r);
                    panel1.Visible = true;
                    listView1.Visible = true;
                }
                else
                {
                    MessageBox.Show("לא מילאת את כל הפרטים הדרושים");
                }
            }
            if(status=="עדכן")
            {
                r = tblR.Find(Convert.ToInt32(txtCodeR.Text));
                r.CodeRechisha = Convert.ToInt32(txtCodeR.Text);
                r.CodeSapak = ((Sapaks)cmbCodeS.SelectedItem).CodeSapak;
                r.DateInvaitition = Convert.ToDateTime(dtpInvit.Value);
                listView1.Visible = true;
                r.DateGetingSchora = Convert.ToDateTime(dtpGet.Value);
                r.Status = false;
                tblR.UpdateRow(r);
                panel1.Visible = true;
            }
        }

        private void dataGridView1_RowHeaderMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            panel2.Visible = true;
            m = tblM.Find(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
            lblCode.Text = m.CodeMutsar.ToString();
            lblName.Text = m.Description.ToString();
        }



        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if(txtSach.Text=="0")
                MessageBox.Show("בחר מוצר");
            else
            {
            if (status == "חדש")
            {
                foreach (ListViewItem item in listView1.Items)
                {
                    mlr = new MutsarimInTheRechisha();
                    mlr.CodeRechisha =r.CodeRechisha;
                    m = tblM.Find(Convert.ToInt32(item.SubItems[1].Text));
                    mlr.CodeMutsar = m.CodeMutsar;
                    mlr.AmountInvatition = Convert.ToInt32(item.SubItems[3].Text);
                    mlr.AmountMitkabelet = 0;
                    mlr.PriceForMutsar = Convert.ToInt32(item.SubItems[3].Text);
                    //m.AmountMelay += Convert.ToInt32(item.SubItems[3].Text);
                    tvlmlr.AddNew(mlr);
                }
            }
            else
            {
                foreach (ListViewItem item in listView1.Items)
                {
                    //mlr = new MutsarimInTheRechisha();
                    mlr= tvlmlr.GetList().FirstOrDefault(x => x.CodeMutsar == (Convert.ToInt32(item.SubItems[1].Text)) && x.CodeRechisha == r.CodeRechisha); //.CodeRechisha = r.CodeRechisha;
                    m = tblM.Find((Convert.ToInt32(item.SubItems[1].Text)));//tvlmlr.GetList().FirstOrDefault(x=>x.CodeMutsar==(Convert.ToInt32(item.SubItems[1].Text))&& x.CodeRechisha==r.CodeRechisha);
                    mlr.CodeMutsar = m.CodeMutsar;
                    mlr.AmountInvatition = Convert.ToInt32(item.SubItems[3].Text);
                    mlr.AmountMitkabelet = 0;
                    mlr.PriceForMutsar = Convert.ToInt32(item.SubItems[3].Text);
                    tvlmlr.UpdateRow(mlr);
                }
            }   
            r.SachHacolRechisha = sum;
                tblR.UpdateRow(r);
                MessageBox.Show("שלום ולהתראות");
                this.Close();
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                sum -= Convert.ToDouble(listView1.SelectedItems[0].SubItems[5].Text);
                txtSach.Text = sum.ToString();
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (lblCode.Text!="")
            {
                m = tblM.GetList().Find(x => x.CodeMutsar == Convert.ToInt32(lblCode.Text));
                sum = Convert.ToDouble(txtSach.Text);
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
                    //if (amount > m.AmountMelay)
                      //  MessageBox.Show("כמות המלאי הינה" + " " + m.AmountMelay + "\n" + "בחר כמות מתאימה");
                    //else
                    {
                        //2 שורות הוספה ל-listview
                        ListViewItem lv = new ListViewItem(new string[] { txtCodeR.Text, m.CodeMutsar.ToString(), m.Description, amount.ToString(), m.PriceBuying.ToString(), (m.PriceBuying * amount).ToString() });
                        listView1.Items.Add(lv);
                        sum += Convert.ToInt32(numericUpDown1.Value) * m.PriceBuying;
                        txtSach.Text = sum.ToString();
                        flag = true;
                        lblCode.Text = "";
                        lblName.Text = "";
                        numericUpDown1.Value = 1;
                    }
                }
               // else
                  // MessageBox.Show("בחר מוצר");
            }
            else
                MessageBox.Show("בחר מוצר");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dtpGet_ValueChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void dtpInvit_ValueChanged(object sender, EventArgs e)
        {
            if (dtpInvit.Value.Date < DateTime.Now.Date)
            {
                dtpInvit.Value = DateTime.Now;
            }
        }
    }
}  




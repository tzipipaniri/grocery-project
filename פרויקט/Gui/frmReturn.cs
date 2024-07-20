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
    public partial class frmReturn : Form
    {
        Buying b;
        BuyingDB tblB;
        MutsarimInTheBuying mlb;
        MutsarimInTheBuyingDB tblmlb;
        Mutsarim m;
        MutsarimDB tblM;
        Customers cust;
        CustomersDB tblCust;
        double sum = 0,s;
        int codeB;
        public frmReturn(int c)
        {
            InitializeComponent();
            tblCust = new CustomersDB();
           codeB = c;
            panel1.Visible = false;
            tblB = new BuyingDB();
            tblmlb = new MutsarimInTheBuyingDB();
            tblM = new MutsarimDB();
            b = tblB.Find(c);
            txtSum.Text = b.SumOfAll.ToString();
            sum = b.SumOfAll;
            s = sum;
            List<MutsarimInTheBuying> lst = tblmlb.GetList().Where(x => x.CodeBuying == Convert.ToInt32(c)).ToList();
            foreach (MutsarimInTheBuying item1 in lst)
            {
                string mu = tblM.Find(item1.CodeMutsar).Description;
                ListViewItem lv = new ListViewItem(new string[] { c.ToString(), item1.CodeMutsar.ToString(), mu, item1.ThisMutsarInTheBuying().Amount.ToString(), item1.SumForMutsar.ToString(), (item1.SumForMutsar * item1.Amount).ToString() });
                lvmlb.Items.Add(lv);
                sum += Convert.ToDouble(item1.SumForMutsar * item1.Amount);
            }
        }

        private void lvmlb_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            panel1.Visible = true;
            txtNameMutsar.Text = lvmlb.SelectedItems[0].SubItems[2].Text;
            int id = Convert.ToInt32(lvmlb.SelectedItems[0].SubItems[3].Text);
            numericUpDown1.Maximum = id;
            numericUpDown1.Value = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNameMutsar.Text == "")
                MessageBox.Show("בחר מוצר להחזרה");
            else
            {
                if (lvmlb.SelectedItems[0].SubItems[3].Text == "0")
                    MessageBox.Show("אין מוצרים להחזרה");
                else
                {
                    int id = Convert.ToInt32(lvmlb.SelectedItems[0].SubItems[3].Text);
                    int a = Convert.ToInt32(numericUpDown1.Value), b = id - a;
                    double price = Convert.ToDouble(lvmlb.SelectedItems[0].SubItems[4].Text);
                    ListViewItem lv = new ListViewItem(new string[] {codeB.ToString(),lvmlb.SelectedItems[0].SubItems[1].Text,lvmlb.SelectedItems[0].SubItems[2].Text
                ,a.ToString(),lvmlb.SelectedItems[0].SubItems[4].Text,(a*price).ToString()});
                    lvReturn.Items.Add(lv);
                    if (b > 0)
                    {
                        ListViewItem lv1 = new ListViewItem(new string[] { codeB.ToString(), lvmlb.SelectedItems[0].SubItems[1].Text, lvmlb.SelectedItems[0].SubItems[2].Text
                ,b.ToString(),lvmlb.SelectedItems[0].SubItems[4].Text,(b*price).ToString()});
                        lvmlb.Items.Add(lv1);
                    }
                    lvmlb.Items.Remove(lvmlb.SelectedItems[0]);
                    s -= a * price;
                    txtSum.Text = s.ToString();
                    txtNameMutsar.Text = "";
                }
            }
        }
        private void frmReturn_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item1 in lvReturn.Items)
            {
                //לחפש לפי הקוד מוצר
                //לעדכן מלאי
                m = tblM.Find(Convert.ToInt32(item1.SubItems[1].Text));
                m.AmountMelay += Convert.ToInt32(item1.SubItems[3].Text);
                tblM.UpdateRow(m);
                mlb = tblmlb.Find(codeB,Convert.ToInt32( item1.SubItems[1].Text));
                mlb.Amount-= Convert.ToInt32(item1.SubItems[3].Text);
                tblmlb.UpdateRow(mlb);
                if(mlb.Amount==0)
                {
                    tblmlb.DeleteRow(mlb.CodeBuying, mlb.CodeMutsar);
                }

            }
            //עדכון מחירים וחוב
            double x = b.SumOfAll - Convert.ToDouble(txtSum.Text);
            if (b.IdCustomer!="325995280")
            {
                cust = tblCust.Find(b.IdCustomer);
                cust.ChovCustomer -= x;
                tblCust.UpdateRow(cust);
            }
            MessageBox.Show("זוכית ב"+x+" שקלים  ");
            b.SumOfAll = Convert.ToDouble(txtSum.Text);
            tblB.UpdateRow(b);
            if (b.SumOfAll == 0)
                tblB.DeleteRow(b.CodeBuying);
            this.Close();
        }
    }
}

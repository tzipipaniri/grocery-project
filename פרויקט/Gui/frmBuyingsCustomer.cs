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
    public partial class frmBuyingsCustomer : Form
    {
        Buying b;
        BuyingDB tblB;
        Customers cust;
        CustomersDB tblCust;
        public frmBuyingsCustomer()
        {
            InitializeComponent();
            groupBox1.Visible = false;
            tblB = new BuyingDB();
            tblCust = new CustomersDB();
            dataGridView1.DataSource = tblB.GetList().Select(x => new { קוד_קניה = x.CodeBuying,שם_לקוח = x.ThisCustomers().ToString(), תאריך = x.DateBuying, סך_הכל = x.SumOfAll }).ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            itemsBuying ib = new itemsBuying("חדש", tblB.GetNextKey(),0,"");
            ib.Show();
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //itemsBuying ib = new itemsBuying("עדכן", Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value),Convert.ToInt32( dataGridView1.SelectedRows[0].Cells[3].Value), dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
            //ib.Show();
            if (dataGridView1.SelectedRows.Count > 0)
            {
                frmReturn r = new frmReturn(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                r.Show();
            }
            else
                MessageBox.Show("בחר קניה להחזרה");
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int kod = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

                b = tblB.Find(kod);
                DialogResult r = MessageBox.Show("אתה בטוח שברצונך למחוק קניה זו ?", "אישור מחיקה", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {

                   // ClearText();

                    int code = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                    tblB.DeleteRow(code);
                    dataGridView1.DataSource = tblB.GetList().Select(x => new { קוד = x.CodeBuying, תז_לקוח = x.IdCustomer,תאריך=x.DateBuying,סך_הכל=x.SumOfAll }).ToList();
                }

            }

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
           txtCode.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtSum.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void btnRaanen_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = tblB.GetList().Select(x => new { קוד_קניה = x.CodeBuying, שם_לקוח = x.ThisCustomers().ToString(), תאריך = x.DateBuying, סך_הכל = x.SumOfAll }).ToList();
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            groupBox1.Visible = false;
        }
    }
}

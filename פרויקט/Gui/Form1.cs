using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using פרויקט.Utilies;
using פרויקט.BLL;
using פרויקט.Gui;

namespace פרויקט
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmCities frmC = new frmCities();
            frmC.Show();
        }

        private void btnKategory_Click(object sender, EventArgs e)
        {
          
        }

        private void btnKategory_Click_1(object sender, EventArgs e)
        {
  frmKategory frmK = new frmKategory();
            frmK.Show();
        }

        private void btnCompany_Click(object sender, EventArgs e)
        {
            frmCompany frmC = new frmCompany();
            frmC.Show();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            frmCustomer frmCust = new frmCustomer();
            frmCust.Show();
        }

        private void btnM_Click(object sender, EventArgs e)
        {
            frmMutsar frmM = new frmMutsar();
            frmM.Show();
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            frmSapak frmS = new frmSapak();
            frmS.Show();
        }

        private void btnReSa_Click(object sender, EventArgs e)
        {
            frmRechishaFromSapak frmReS = new frmRechishaFromSapak();
            frmReS.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmBuyingsCustomer f = new frmBuyingsCustomer();
            f.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            btnCity.Visible = true;
            btnKategory.Visible = true;
            btnCompany.Visible = true;
            btnCustomer.Visible = true;
            btnM.Visible = true;
            btnS.Visible = true;
        }

        private void btnGeneral_Click(object sender, EventArgs e)
        {

        }

        //private void btnGetSchora_Click(object sender, EventArgs e)
        //{
        //    //frmUpdate f = new frmUpdate();
        //    //f.Show();
        //}
    }
}

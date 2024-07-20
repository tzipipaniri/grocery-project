using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using פרויקט.Dal;


namespace פרויקט.BLL
{
   public class Buying
    {
        public DataRow dr;
        private int codeBuying;
        private string idCustomer;
        private DateTime dateBuying;
        private double sumOfAll;

        public Buying()
        {
        }
        public Buying(DataRow dr)
        {
            this.dr = dr;
            this.codeBuying =Convert.ToInt32(dr["codeBuying"]);
            this.idCustomer = dr["idCustomer"].ToString();
            this.dateBuying =Convert.ToDateTime( dr["dateBuying"]);
            this.sumOfAll =Convert.ToDouble( dr["sumOfAll"]);
        }
        public void FillDataRow()
        {
            dr["codeBuying"] = codeBuying;
            dr["idCustomer"] = idCustomer;
            dr["dateBuying"] = dateBuying;
            dr["sumOfAll"] = sumOfAll;
        }
        public override string ToString()
        {
            return idCustomer;
        }
       // public Buying ThisBuyig()
       // {

       // }

        public Buying(int codeBuying, string idCustomer, DateTime dateBuying, double sumOfAll)
        {
            this.codeBuying = codeBuying;
            this.idCustomer = idCustomer;
            this.dateBuying = dateBuying;
            this.sumOfAll = sumOfAll;
        }

        public int CodeBuying { get => codeBuying; set=> codeBuying = value; } 
        public string IdCustomer { get => idCustomer; set { if (!Utilies.ValidateUtil.LegalId(value)) throw new Exception("ת.ז. לא תקינה"); idCustomer = value; } }
        public DateTime DateBuying { get => dateBuying; set => dateBuying=value; }
        public double SumOfAll { get => sumOfAll; set => sumOfAll = value; }
        public Buying ThisBuying()
        {
            BuyingDB tblBuying = new BuyingDB();
            return tblBuying.Find(this.codeBuying);
        }
        public Customers ThisCustomers()
        {
            CustomersDB tblCust = new CustomersDB();
            return tblCust.Find(this.idCustomer);
        }
    }
}

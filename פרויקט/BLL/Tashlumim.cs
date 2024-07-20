using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using פרויקט.Dal;

namespace פרויקט.BLL
{
  public  class Tashlumim
    {
        public DataRow dr;
        private int codeTashlum;
        private string idCustomer;
        private double sumOfAllTashlum;
        private int numTashlumim;
        private string ofenTashlum;
        private DateTime date;
        private string numTicket;
        private DateTime tokef;
        private string idManOfTicket;
        private string threeDigits;

        public Tashlumim()
        {
        }
        public Tashlumim(DataRow dr)
        {
            this.dr = dr;
            this.codeTashlum =Convert.ToInt32( dr["codeTashlum"]);
            this.idCustomer = dr["idCustomer"].ToString();
            this.sumOfAllTashlum =Convert.ToDouble( dr["sumOfAllTashlum"]);
            this.numTashlumim =Convert.ToInt32( dr["numTashlumim"]);
            this.ofenTashlum = dr["ofenTashlum"].ToString();
            this.date =Convert.ToDateTime( dr["date1"]);
            this.numTicket =dr["numTicket"].ToString();
            this.tokef =Convert.ToDateTime( dr["tokef"]);
            this.idManOfTicket = dr["idManOfTicket"].ToString();
            this.threeDigits = dr["threeDigits"].ToString();
        }
        public void FillDataRow()
        {
            dr["codeTashlum"] = codeTashlum;
            dr["idCustomer"] = idCustomer;
            dr["sumOfAllTashlum"] = sumOfAllTashlum;
            dr["numTashlumim"] = numTashlumim;
            dr["ofenTashlum"] = ofenTashlum;
            dr["date1"] = date;
            dr["numTicket"] = numTicket;
            dr["tokef"] = tokef;
            dr["idManOfTicket"] = idManOfTicket;
            dr["threeDigits"] = threeDigits;
        }
        public override string ToString()
        {
            return sumOfAllTashlum.ToString()+" "+numTashlumim+" "+ofenTashlum+" "+date+" "+numTicket+" "+tokef+" "+threeDigits;
        }

        //public Tashlumim(int codeTashlum, string idCustomer,double sumOfAllTashlum, string numTashlumim, 
        //    string ofenTashlum, DateTime date, int numTicket, string tokef, string idManOfTicket, string threeDigits)
        //{
        //    this.codeTashlum = codeTashlum;
        //    this.idCustomer = idCustomer;
        //    this.sumOfAllTashlum = sumOfAllTashlum;
        //    //this.numTashlumim = numTashlumim;
        //    //this.ofenTashlum = ofenTashlum;
        //    //this.date = date;
        //    //this.numTicket = numTicket;
        //    this.tokef = tokef;
        //    this.idManOfTicket = idManOfTicket;
        //    this.threeDigits = threeDigits;
        //}

        public int CodeTashlum { get => codeTashlum; set => codeTashlum = value; }
        public string IdCustomer { get => idCustomer; set { if (!Utilies.ValidateUtil.LegalId(value)) throw new Exception("ת.ז. לא תקינה"); idCustomer = value; } }
        public double SumOfAllTashlum { get => sumOfAllTashlum; set => sumOfAllTashlum = value; }
        public int NumTashlumim { get => numTashlumim; set => numTashlumim = value; }
        public string OfenTshlum { get => ofenTashlum; set => ofenTashlum = value; }
        public DateTime Date { get => date; set => date = value; }
        public string NumTicket { get => numTicket; set { if (!Utilies.ValidateUtil.checkVisa(value)) throw new Exception("מס' כרטיס לא תקין"); numTicket = value; } }
        public DateTime Tokef { get => tokef; set => tokef = value; }
        public string IdManOfTicket { get => idManOfTicket; set { if (!Utilies.ValidateUtil.LegalId(value)) throw new Exception("ת.ז. לא תקינה"); idManOfTicket = value; } }
        public string ThreeDigits { get => threeDigits; set { if (!Utilies.ValidateUtil.IsNum(value)) throw new Exception("יש להזין מספרים בלבד");if (value.Length > 3) throw new Exception("יש להזין 3 ספרות בלבד"); threeDigits = value; } }
        public Tashlumim ThisTashlum()
        {
            TashlumimDB tblTshlumim = new TashlumimDB();
            return tblTshlumim.Find(this.codeTashlum);
        }
        public Customers ThisCustomers()
        {
            CustomersDB tblCust = new CustomersDB();
            return tblCust.Find(this.idCustomer);
        }
    }
}

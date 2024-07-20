using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using פרויקט.Dal;

namespace פרויקט.BLL
{
  public  class Mutsarim
    {
        public DataRow dr;
        private int codeMutsar;
        private int kategory;
        private int company;
        private double priceBuying;
        private double priceSell;
        private int amountMelay;
        private string description;
        private bool status;
        public Mutsarim()
        {
        }
        public Mutsarim(DataRow dr)
        {
            this.dr = dr;
            this.codeMutsar =Convert.ToInt32( dr["codeMutsar"]);
            this.kategory =Convert.ToInt32( dr["kategory"]);
            this.company = Convert.ToInt32(dr["company"]);
            this.priceBuying =Convert.ToDouble( dr["priceBuying"]);
            this.priceSell =Convert.ToDouble( dr["priceSell"]);
            this.amountMelay =Convert.ToInt32( dr["amountMelay"]);
            this.description = dr["description"].ToString();
            this.status =Convert.ToBoolean( dr["status"]);
        }
        public void FillDataRow()
        {
            dr["codeMutsar"] = codeMutsar;
            dr["kategory"] = kategory;
            dr["company"] = company;
            dr["priceBuying"] = priceBuying;
            dr["priceSell"] = priceSell;
            dr["amountMelay"] = amountMelay;
            dr["description"] = description;
            dr["status"] = status;
        }
        public override string ToString()
        {
            return description;
        }

        //public Mutsarim(int codeMutsar, string kategory, string company,
        //    double priceBuying, double priceSell, int amountMelay, string description)
        //{
        //    this.codeMutsar = codeMutsar;
        //    this.kategory = kategory;
        //    this.company = company;
        //    this.priceBuying = priceBuying;
        //    this.priceSell = priceSell;
        //    this.amountMelay = amountMelay;
        //    this.description = description;
        //}

        public int CodeMutsar { get => codeMutsar; set => codeMutsar = value; }
        public int Kategory { get => kategory; set => kategory = value; } 
        public int Company { get => company; set => company = value; } 
        public double PriceBuying { get => priceBuying; set { if (!Utilies.ValidateUtil.IsNumDouble(value.ToString())) throw new Exception("יש להזין מספרים בלבד"); priceBuying = value; } }
        public double PriceSell { get => priceSell; set { if (!Utilies.ValidateUtil.IsNumDouble(value.ToString())) throw new Exception("יש להזין מספרים בלבד"); priceSell = value; } }
        public int AmountMelay { get => amountMelay; set { if (!Utilies.ValidateUtil.IsNum(value.ToString())) throw new Exception("יש להזין מספרים בלבד"); amountMelay = value; } }
        public string Description { get => description; set { if (!Utilies.ValidateUtil.IsHebrew(value) && !Utilies.ValidateUtil.IsEnglish(value)) throw new Exception("יש להזין אותיות בלבד"); if (value.Length <2) throw new Exception("יש לכתוב תאור תקין"); description = value; } }

        public bool Status { get => status; set => status = value; }

        public Mutsarim ThisMutsar()
        {
            MutsarimDB tblMutsarim = new MutsarimDB();
            return tblMutsarim.Find(this.codeMutsar);
        }
        public Kategories ThisKategory()
        {
            KategoriesDB tblKategories = new KategoriesDB();
            return tblKategories.Find(this.kategory);
        }
        public Companies ThisCompanies()
        {
            CompaniesDB tblCompanies = new CompaniesDB();
            return tblCompanies.Find(this.company);
        }
    }
}

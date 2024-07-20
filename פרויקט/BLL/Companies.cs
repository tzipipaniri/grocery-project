using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using פרויקט.Dal;

namespace פרויקט.BLL
{
   public class Companies
    {
        public DataRow dr;
        private int code;
        private string nameCompany;

        public Companies()
        {
        }
        public Companies(DataRow dr)
        {
            this.dr = dr;
            this.code =Convert.ToInt32( dr["code"]);
            this.nameCompany = dr["nameCompany"].ToString();

        }
        public void FillDataRow()
        {
            dr["code"] = code;
            dr["nameCompany"] = nameCompany;
        }
        public override string ToString()
        {
            return nameCompany;
        }

        public Companies(int code, string nameCompany)
        {
            this.code = code;
            this.nameCompany = nameCompany;
        }

        public int Code { get => code; set => code = value; }
        public string NameCompany { get => nameCompany; set { if (!Utilies.ValidateUtil.IsHebrew(value) && !Utilies.ValidateUtil.IsEnglish(value)) throw new Exception("יש להזין אותיות בלבד"); if (value.Length <2 ) throw new Exception("יש לכתוב חברה תקינה"); nameCompany = value; } }
        public Companies ThisCompanies()
        {
           CompaniesDB  tblCompanies = new CompaniesDB();
            return tblCompanies.Find(this.Code);
        }
    }
}

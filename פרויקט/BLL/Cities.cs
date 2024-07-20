using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using פרויקט.Dal;

namespace פרויקט.BLL
{
  public  class Cities
    {
      public  DataRow dr;
        private int codeCity;
        private string nameOfCity;

        public Cities()
        {
        }
        public Cities(DataRow dr)
        {
            this.dr = dr;
            this.codeCity =Convert.ToInt32( dr["codeCity"]);
            this.nameOfCity = dr["nameOfCity"].ToString();
        }
        public void FillDataRow()
        {
            dr["codeCity"] = codeCity;
            dr["nameOfCity"] = nameOfCity;
        }
        public override string ToString()
        {
            return nameOfCity;
        }
        public Cities(int codeCity, string nameOfCity)
        {
            this.codeCity = codeCity;
            this.nameOfCity = nameOfCity;
        }

        public int CodeCity { get => codeCity; set => codeCity = value; }
        public string NameOfCity { get => nameOfCity; set { if (!Utilies.ValidateUtil.IsHebrew(value)&&!Utilies.ValidateUtil.IsEnglish(value)) throw new Exception("יש להזין אותיות בלבד");if (value.Length<2) throw new Exception("יש לכתוב עיר תקינה"); nameOfCity = value; } }
        public Cities ThisCities()
        {
            CitiesDB  tblCities= new CitiesDB();
            return tblCities.Find(this.CodeCity);
        }
    }
}

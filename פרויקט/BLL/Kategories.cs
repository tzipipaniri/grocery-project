using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using פרויקט.Dal;

namespace פרויקט.BLL
{
    public class Kategories
    {
        public DataRow dr;
        private int code;
        private string description;

        public Kategories()
        {
        }
        public Kategories(DataRow dr)
        {
            this.dr = dr;
            this.code =Convert.ToInt32( dr["code"]);
            this.description = dr["description"].ToString();
        }
        public void FillDataRow()
        {
            dr["code"] = code;
            dr["description"] = description;
        }
        public override string ToString()
        {
            return  description;
        }

        public Kategories(int code, string description)
        {
            this.code = code;
            this.description = description;
        }

        public int Code { get => code; set => code = value; }
        public string Description { get => description; set { if ((!Utilies.ValidateUtil.IsEnglish(value) && (!Utilies.ValidateUtil.IsHebrew(value)))) throw new Exception("יש להזין אותיות בלבד"); if (value.Length == 1) throw new Exception("יש לכתוב קטגוריה תקינה"); description = value; } }
        public DataRow Dr { get => dr; set => dr = value; }
        public Kategories ThisKategory()
        {
           KategoriesDB tblKategories = new KategoriesDB();
            return tblKategories.Find(this.code);
        }
    }
}

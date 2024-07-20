using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using פרויקט.Dal;

namespace פרויקט.BLL
{
  public  class Sapaks
    {
        public DataRow dr;
        private int codeSapak;
        private string nameOfSapak;
        private bool status;

        public Sapaks()
        {
        }
        public Sapaks(DataRow dr)
        {
            this.dr = dr;
            this.codeSapak =Convert.ToInt32( dr["codeSapak"]);
            this.nameOfSapak = dr["nameOfSapak"].ToString();
            this.status =Convert.ToBoolean( dr["status"]);
        }
        public void FillDataRow()
        {
            dr["codeSapak"] = codeSapak;
            dr["nameOfSapak"] = nameOfSapak;
            dr["status"] = status;
        }
        public override string ToString()
        {
            return nameOfSapak;
        }

        //public Sapaks(int codeSapak, string nameOfSapak)
        //{
        //    this.codeSapak = codeSapak;
        //    this.nameOfSapak = nameOfSapak;
        //}

        public int CodeSapak { get => codeSapak; set => codeSapak = value; }
        public string NameOfSapak { get => nameOfSapak; set { if (!Utilies.ValidateUtil.IsHebrew(value) && !Utilies.ValidateUtil.IsEnglish(value)) throw new Exception("יש להזין אותיות בלבד"); if (value.Length <2) throw new Exception("יש לכתוב שם ספק תקין"); nameOfSapak = value; } }

        public bool Status { get => status; set => status = value; }

        public Sapaks ThisSapak()
        {
            SapaksDB tblSapaks = new SapaksDB();
            return tblSapaks.Find(this.codeSapak);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using פרויקט.Dal;

namespace פרויקט.BLL
{
  public  class Rechishas
    {
        public DataRow dr;
        private int codeRechisha;
        private int codeSapak;
        private DateTime dateInvaitition;
        private double sachHacolRechisha;
        private DateTime dateGetingSchora;
        private bool status;

        public Rechishas()
        {
        }
        public Rechishas(DataRow dr)
        {
            this.dr = dr;
            this.codeRechisha =Convert.ToInt32( dr["codeRechisha"]);
            this.codeSapak =Convert.ToInt32( dr["codeSapak"]);
            this.dateInvaitition =Convert.ToDateTime( dr["dataInvaitition"]);
            this.sachHacolRechisha =Convert.ToDouble( dr["sachHacolRechisha"]);
            this.dateGetingSchora =Convert.ToDateTime( dr["dateGetingSchora"]);
            this.status =Convert.ToBoolean( dr["status"]);
        }
        public void FillDataRow()
        {
            dr["codeRechisha"] = codeRechisha;
            dr["codeSapak"] = codeSapak;
            dr["dataInvaitition"] = dateInvaitition;
            dr["sachHacolRechisha"] = sachHacolRechisha;
            dr["dateGetingSchora"] = dateGetingSchora;
            dr["status"] = status;

        }
        public override string ToString()
        {
            return dateInvaitition+" "+SachHacolRechisha+" "+dateGetingSchora;
        }


        //public Rechishas(int codeRechisha, int codeSapak, DateTime dateInvaitition,
        //    int sachHacolRechisha, DateTime dateGetingSchora, string status)
        //{
        //    this.codeRechisha = codeRechisha;
        //    this.codeSapak = codeSapak;
        //    this.dateInvaitition = dateInvaitition;
        //    this.sachHacolRechisha = sachHacolRechisha;
        //    this.dateGetingSchora = dateGetingSchora;
        //    this.status = status;
        //}

        public int CodeRechisha { get => codeRechisha; set => codeRechisha = value; }
        public int CodeSapak { get => codeSapak; set => codeSapak = value; }
        public DateTime DateInvaitition { get => dateInvaitition; set => dateInvaitition = value; }
        public double SachHacolRechisha { get => sachHacolRechisha; set => sachHacolRechisha = value; }
        public DateTime DateGetingSchora { get => dateGetingSchora; set => dateGetingSchora = value; }
        public bool Status { get => status; set => status = value; }
        public Rechishas ThisRechisha()
        {
            RechishasDB tblRechishas = new RechishasDB();
            return tblRechishas.Find(this.codeRechisha);
        }
        public Sapaks ThisSapak()
        {
            SapaksDB tblSapaks = new SapaksDB();
            return tblSapaks.Find(this.codeSapak);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using פרויקט.Dal;

namespace פרויקט.BLL
{
   public class PratimOfTashlum
    {
        public DataRow dr;
        private int numTashlum;
        private int codeTashlum;
        private double sumForTashlum;
        private DateTime date;
        public PratimOfTashlum()
        {
        }
        public PratimOfTashlum(DataRow dr)
        {
            this.dr = dr;
            this.numTashlum =Convert.ToInt32( dr["numTashlum"]);
            this.codeTashlum =Convert.ToInt32( dr["codeTashlum"]);
            this.sumForTashlum =Convert.ToDouble( dr["sumForTashlum"]);
            this.date = Convert.ToDateTime(dr["date1"]);
        }
        public void FillDataRow()
        {
            dr["numTashlum"] = numTashlum;
            dr["codeTashlum"] = codeTashlum;
            dr["sumForTashlum"] = sumForTashlum;
            dr["date1"] = date;
        }
        public override string ToString()
        {
            return numTashlum+" "+sumForTashlum;
        }

        //public PratimOfTashlum(int numTashlum, int codeTashlum, double sumForTashlum)
        //{
        //    this.numTashlum = numTashlum;
        //    this.codeTashlum = codeTashlum;
        //    this.sumForTashlum = sumForTashlum;
        //    this.date = date;
        //}

        public int NumTashlum { get => numTashlum; set => numTashlum = value; }
        public int CodeTashlum { get => codeTashlum; set => codeTashlum = value; }
        public double SumForTashlum { get => sumForTashlum; set => sumForTashlum = value; }
        public DateTime Date { get => date; set => date = value; }

        public PratimOfTashlum ThisPratimOfTashlum()
        {
            PratimOfTashlumDB tblPratimOfTashlum = new PratimOfTashlumDB();
            return tblPratimOfTashlum.Find(this.codeTashlum);
        }
        public Tashlumim ThisTashlum()
        {
            TashlumimDB tblTshlumim = new TashlumimDB();
            return tblTshlumim.Find(this.codeTashlum);
        }
    }
}

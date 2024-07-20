using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using פרויקט.Dal;

namespace פרויקט.BLL
{
   public class MutsarimInTheRechisha
    {
        public DataRow dr;
        private int codeRechisha;
        private int codeMutsar;
        private int amountInvatition;
        private int amountMitkabelet;
        private double priceForMutsar;

        public MutsarimInTheRechisha()
        {
        }
        public MutsarimInTheRechisha(DataRow dr)
        {
            this.dr = dr;
            this.codeRechisha =Convert.ToInt32( dr["codeRechisha"]);
            this.codeMutsar =Convert.ToInt32( dr["codeMutsar"]);
            this.amountInvatition =Convert.ToInt32( dr["amountInvaitition"]);
            this.amountMitkabelet =Convert.ToInt32( dr["amountMitkabelet"]);
            this.priceForMutsar =Convert.ToDouble( dr["priceForMutsar"]);
        }
        public void FillDataRow()
        {
            dr["codeRechisha"] = codeRechisha;
            dr["codeMutsar"] = codeMutsar;
            dr["amountInvaitition"] = amountInvatition;
            dr["amountMitkabelet"] = amountMitkabelet;
            dr["priceForMutsar"] = priceForMutsar;
        }
        public override string ToString()
        {
            return codeMutsar.ToString();
        }

        public int CodeRechisha { get => codeRechisha; set => codeRechisha = value; }
        public int CodeMutsar { get => codeMutsar; set => codeMutsar = value; }
        public int AmountInvatition { get => amountInvatition; set => amountInvatition = value; }
        public int AmountMitkabelet { get => amountMitkabelet; set => amountMitkabelet = value; }
        public double PriceForMutsar { get => priceForMutsar; set => priceForMutsar = value; }
        public MutsarimInTheRechisha ThisMutsarInTheRechisha()
        {
            MutsarimInTheRechishaDB tblMutsarimInTheRechisha = new MutsarimInTheRechishaDB();
            return tblMutsarimInTheRechisha.Find(this.codeRechisha,this.codeMutsar);
        }
        public Mutsarim ThisMutsar()
        {
            MutsarimDB tblMutsarim = new MutsarimDB();
            return tblMutsarim.Find(this.codeMutsar);
        }
        public Rechishas ThisRechisha()
        {
            RechishasDB tblRechishas = new RechishasDB();
            return tblRechishas.Find(this.codeRechisha);
        }
    }
}

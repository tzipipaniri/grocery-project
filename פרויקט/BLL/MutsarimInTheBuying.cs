using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using פרויקט.Dal;

namespace פרויקט.BLL
{
   public class MutsarimInTheBuying
    {
        public DataRow dr;
        private int codeBuying;
        private int codeMutsar;
        private int amount;
        private double sumForMutsar;

        public MutsarimInTheBuying()
        {
        }
        public MutsarimInTheBuying(DataRow dr)
        {
            this.dr = dr;
            this.codeBuying =Convert.ToInt32( dr["codeBuying"]);
            this.codeMutsar =Convert.ToInt32( dr["codeMutsar"]);
            this.amount =Convert.ToInt32( dr["amount"]);
            this.sumForMutsar =Convert.ToDouble( dr["sumForMutsar"]);
        }
        public void FillDataRow()
        {
           dr["codeBuying"] = codeBuying;
            dr["codeMutsar"] = codeMutsar;
            dr["amount"] = amount;
            dr["sumForMutsar"] = sumForMutsar;
        }
        public override string ToString()
        {
            return amount+" "+sumForMutsar;
        }

        public MutsarimInTheBuying(int codeBuying, int codeMutsar, int amount, double sumForMutsar)
        {
            this.codeBuying = codeBuying;
            this.codeMutsar = codeMutsar;
            this.amount = amount;
            this.sumForMutsar = sumForMutsar;
        }

        public int CodeBuying { get => codeBuying; set => codeBuying = value; }
        public int CodeMutsar { get => codeMutsar; set => codeMutsar = value; } 
        public int Amount { get => amount; set => amount = value; }
        public double SumForMutsar { get => sumForMutsar; set => sumForMutsar = value; }
        public MutsarimInTheBuying ThisMutsarInTheBuying()
        {
            MutsarimInTheBuyingDB tblMutsarimInTheBuying = new MutsarimInTheBuyingDB();
            return tblMutsarimInTheBuying.Find(this.codeBuying,this.CodeMutsar);
        }
        public Buying ThisBuying()
        {
            BuyingDB tblBuying = new BuyingDB();
            return tblBuying.Find(this.codeBuying);
        }
        public Mutsarim ThisMutsar()
        {
            MutsarimDB tblMutsarim = new MutsarimDB();
            return tblMutsarim.Find(this.codeMutsar);
        }
    }
}

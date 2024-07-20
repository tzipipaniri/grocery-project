using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace פרויקט.BLL
{
  public  class MutsarimInTheBuyingDB:GeneralDB
    {
        public MutsarimInTheBuyingDB() : base("MutsarimInTheBuying") { }
        protected List<MutsarimInTheBuying> list = new List<MutsarimInTheBuying>();
        private void DataTableToList()
        {
            foreach (DataRow dr in table.Rows)
            {
                list.Add(new MutsarimInTheBuying(dr));
            }
        }
        public List<MutsarimInTheBuying> GetList()
        {
            list.Clear();
            DataTableToList();
            return list;
        }
        public void AddNew(MutsarimInTheBuying mutsarimInTheBuy)
        {
            mutsarimInTheBuy.dr = table.NewRow();
            mutsarimInTheBuy.FillDataRow();
            this.Add(mutsarimInTheBuy.dr);
        }
        public MutsarimInTheBuying Find(int code,int codem)
        {
            return this.GetList().Find(x =>x.CodeBuying ==code&&x.CodeMutsar==codem);
        }
        public void Update()
        {
            Dal.Dal.GetInstance().Update(table.TableName);
        }
        public void UpdateRow(MutsarimInTheBuying mutsarimInTheBuy)
        {
            mutsarimInTheBuy.FillDataRow();
            this.Update();
        }
        public int GetNextKey()
        {
            if (this.Size() == 0)
                return 1;
            return this.GetList().Max(x => x.CodeBuying) + 1;

        }
        public void DeleteRow(int codeBuying,int codemut)
        {
            MutsarimInTheBuying mutsarInTheB = this.Find(codeBuying,codemut);
            if (mutsarInTheB!= null)
            {
               mutsarInTheB.dr.Delete();
                this.Update();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace פרויקט.BLL
{
  public  class MutsarimInTheRechishaDB:GeneralDB
    {
        public MutsarimInTheRechishaDB() : base("MutsarimInTheRechisha") { }
        protected List<MutsarimInTheRechisha> list = new List<MutsarimInTheRechisha>();
        private void DataTableToList()
        {
            foreach (DataRow dr in table.Rows)
            {
                list.Add(new MutsarimInTheRechisha(dr));
            }
        }
        public List<MutsarimInTheRechisha> GetList()
        {
            list.Clear();
            DataTableToList();
            return list;
        }
        public void AddNew(MutsarimInTheRechisha mutsarimInTheR)
        {
            mutsarimInTheR.dr = table.NewRow();
            mutsarimInTheR.FillDataRow();
            this.Add(mutsarimInTheR.dr);
        }
        public MutsarimInTheRechisha Find(int codere,int codenu)
        {
            return this.GetList().Find(x => x.CodeRechisha == codere&&x.CodeMutsar==codenu);
        }
        public void Update()
        {
            Dal.Dal.GetInstance().Update(table.TableName);
        }
        public void UpdateRow(MutsarimInTheRechisha mutsarimInTheR)
        {
            mutsarimInTheR.FillDataRow();
            this.Update();
        }
        public int GetNextKey()
        {
            if (this.Size() == 0)
                return 1;
            return this.GetList().Max(x => x.CodeRechisha) + 1;

        }
        public void DeleteRow(int codeR,int codeM)
        {
           MutsarimInTheRechisha mutsarimInR= this.Find(codeR,codeM);
            if (mutsarimInR!= null)
            {
               mutsarimInR.dr.Delete();
                this.Update();
            }
        }
    }
}

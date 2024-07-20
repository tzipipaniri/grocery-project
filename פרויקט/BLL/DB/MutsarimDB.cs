using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace פרויקט.BLL
{
  public  class MutsarimDB:GeneralDB
    {
        public MutsarimDB() : base("Mutsarim") { }
        protected List<Mutsarim> list = new List<Mutsarim>();
        private void DataTableToList()
        {
            foreach (DataRow dr in table.Rows)
            {
                list.Add(new Mutsarim(dr));
            }
        }
        public List<Mutsarim> GetList()
        {
            list.Clear();
            DataTableToList();
            return list;
        }
        public void AddNew(Mutsarim mutsar)
        {
            mutsar.dr = table.NewRow();
            mutsar.FillDataRow();
            this.Add(mutsar.dr);
        }
        public Mutsarim Find(int code)
        {
            return this.GetList().Find(x => x.CodeMutsar == code);
        }


        public void Update()
        {
            Dal.Dal.GetInstance().Update(table.TableName);
        }
        public void UpdateRow(Mutsarim mutsar)
        {
           mutsar.FillDataRow();
            this.Update();
        }
        public int GetNextKey()
        {
            if (this.Size() == 0)
                return 1;
            return this.GetList().Max(x => x.CodeMutsar) + 1;

        }
        public void DeleteRow(int codeMutsar)
        {
            Mutsarim mutsar= this.Find(codeMutsar);
            if (mutsar!= null)
            {
                mutsar.dr.Delete();
                this.Update();
            }
        }
    }
}

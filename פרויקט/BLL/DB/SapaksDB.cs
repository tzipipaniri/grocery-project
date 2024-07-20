using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace פרויקט.BLL
{
  public  class SapaksDB:GeneralDB
    {
        public SapaksDB() : base("Sapaks") { }
        protected List<Sapaks> list = new List<Sapaks>();
        private void DataTableToList()
        {
            foreach (DataRow dr in table.Rows)
            {
                list.Add(new Sapaks(dr));
            }
        }
        public List<Sapaks> GetList()
        {
            list.Clear();
            DataTableToList();
            return list;
        }
        public void AddNew(Sapaks sapak)
        {
            sapak.dr = table.NewRow();
            sapak.FillDataRow();
            this.Add(sapak.dr);
        }
        public Sapaks Find(int code)
        {
            return this.GetList().Find(x => x.CodeSapak == code);
        }
        public void Update()
        {
            Dal.Dal.GetInstance().Update(table.TableName);
        }
        public void UpdateRow(Sapaks sapak)
        {
            sapak.FillDataRow();
            this.Update();
        }
        public int GetNextKey()
        {
            if (this.Size() == 0)
                return 1;
            return this.GetList().Max(x => x.CodeSapak) + 1;

        }
        public void DeleteRow(int code)
        {
            Sapaks sapak= this.Find(code);
            if (sapak != null)
            {
                sapak.dr.Delete();
                this.Update();
            }
        }
    }
}

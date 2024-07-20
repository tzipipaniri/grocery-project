using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace פרויקט.BLL
{
   public class BuyingDB:GeneralDB
    {
        public BuyingDB() : base("Buying") { }
        protected List<Buying> list = new List<Buying>();
        private void DataTableToList()
        {
            foreach (DataRow dr in table.Rows)
            {
                list.Add(new Buying(dr));
            }
        }
        public List<Buying> GetList()
        {
            list.Clear();
            DataTableToList();
            return list;
        }
        public void AddNew(Buying buy)
        {
           buy.dr = table.NewRow();
           buy.FillDataRow();
            this.Add(buy.dr);
        }
        public Buying Find(int code)
        {
            return this.GetList().Find(x => x.CodeBuying == code);
        }
        public void Update()
        {
            Dal.Dal.GetInstance().Update(table.TableName);
        }
        public void UpdateRow(Buying buy)
        {
            buy.FillDataRow();
            this.Update();
        }
        public int GetNextKey()
        {
            if (this.Size() == 0)
                return 1;
            return this.GetList().Max(x => x.CodeBuying) + 1;

        }
        public void DeleteRow(int codeBuying)
        {
            Buying buy = this.Find(codeBuying);
            if (buy != null)
            {
                buy.dr.Delete();
                this.Update();
            }
        }
    }
}

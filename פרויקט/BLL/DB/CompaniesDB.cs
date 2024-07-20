using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace פרויקט.BLL
{
   public  class CompaniesDB:GeneralDB
    {
        public CompaniesDB() : base("Companies") { }
        protected List<Companies> list = new List<Companies>();
      private void DataTableToList()
        {
            foreach (DataRow dr in table.Rows)
            {
                list.Add(new Companies(dr));
            }
        }
        public List<Companies> GetList()
        {
            list.Clear();
            DataTableToList();
            return list;
        }
        public void AddNew(Companies company)
        {
            company.dr = table.NewRow();
           company.FillDataRow();
            this.Add(company.dr);
        }
        public Companies Find(int code)
        {
            return this.GetList().Find(x => x.Code == code);
        }
        public void Update()
        {
            Dal.Dal.GetInstance().Update(table.TableName);
        }
        public void UpdateRow(Companies company)
        {
            company.FillDataRow();
            this.Update();
        }
        public int GetNextKay()
        {
            if (this.Size() == 0)
                return 1;
            return this.GetList().Max(x => x.Code) + 1;
        }
        public void DeleteRow(int code)
        {
            Companies company = this.Find(code);
            if (company != null)
            {
                company.dr.Delete();
                this.Update();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace פרויקט.BLL
{
    public class CustomersDB : GeneralDB
    {
        public CustomersDB() : base("Customers") { }
        protected List<Customers> list = new List<Customers>();
        private void DataTableToList()
        {
            foreach (DataRow dr in table.Rows)
                list.Add(new Customers(dr));
        }
        public List<Customers> GetList()
        {
            list.Clear();
            DataTableToList();
            return list;
        }
        public void AddNew(Customers cust)
        {
            cust.dr = table.NewRow();
            cust.FillDataRow();
            this.Add(cust.dr);
        }
        public Customers Find(string idCustomer)
        {
            return this.GetList().Find(x => x.IdCustomer == idCustomer);
        }
        public void Update()
        {
            Dal.Dal.GetInstance().Update(table.TableName);
        }
        public void UpdateRow(Customers cust)
        {
            cust.FillDataRow();
            this.Update();
        }
        public void DeleteRow(string idCustomer)
        {
            Customers cust = this.Find(idCustomer);
            if (cust!= null)
            {
                cust.dr.Delete();
                this.Update();
            }
        }
        public void DeleteStatus(string id)
        {
            Customers cust = this.Find(id);
            if (cust != null)
            {
                cust.Status = false;
                this.UpdateRow(cust);
            }
        }
        public int GetNextKay()
          {
            if (this.Size() == 0)
                return 1;
            return this.GetList().Max(x => x.City) + 1;
          }
        //public int GetNextKay()
        //{
        //    if (this.Size() == 0)
        //        return 1;
        //    return this.GetList().Max(x => x.IdCustomer) + 1;
        //}
    }
}

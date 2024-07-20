using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace פרויקט.BLL
{
  public  class CitiesDB : GeneralDB
    {
        public CitiesDB() : base("Cities") { }
        protected List<Cities> list = new List<Cities>();
        private void DataTableToList()
        {
            foreach (DataRow dr in table.Rows)
            {
                list.Add(new Cities(dr));
            }
        }
        public List<Cities> GetList()
        {
            list.Clear();
            DataTableToList();
            return list;
        }
        public void AddNew(Cities city)
        {
            city.dr = table.NewRow();
            city.FillDataRow();
            this.Add(city.dr);
        }
        public Cities Find(int code)
        {
            return this.GetList().Find(x => x.CodeCity == code);
        }
        public void Update()
        {
            Dal.Dal.GetInstance().Update(table.TableName);
        }
        public void UpdateRow(Cities city)
        {
           city.FillDataRow();
            this.Update();
        }
        public int GetNextKey()
        {
            if (this.Size() == 0)
                return 1;
            return this.GetList().Max(x => x.CodeCity) + 1;

        }
        public void DeleteRow(int code)
        {
           Cities city= this.Find(code);
            if (city != null)
            {
               city.dr.Delete();
                this.Update();
            }
        }
        //public void DeleteRow(int codeCity)
        //{
        //    Cities city = this.Find(codeCity);
        //    if (city != null)
        //    {
        //        city.dr.Delete();
        //        this.Update();
        //    }
        //}
    }
}

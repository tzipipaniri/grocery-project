using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using System.Data;

namespace פרויקט.BLL
{
  public  class RechishasDB:GeneralDB
    {
        public RechishasDB() : base("Rechishas") { }
        protected List<Rechishas> list = new List<Rechishas>();
        private void DataTableToList()
        {
            foreach (DataRow dr in table.Rows)
            {
                list.Add(new Rechishas(dr));
            }
        }
        public List<Rechishas> GetList()
        {
            list.Clear();
            DataTableToList();
            return list;
        }
        public void AddNew(Rechishas rechisha)
        {
           rechisha.dr = table.NewRow();
            rechisha.FillDataRow();
            this.Add(rechisha.dr);
        }
        public Rechishas Find(int code)
        {
            return this.GetList().Find(x => x.CodeRechisha == code);
        }
        public void Update()
        {
            Dal.Dal.GetInstance().Update(table.TableName);
        }
        public void UpdateRow(Rechishas rechisha)
        {
            rechisha.FillDataRow();
            this.Update();
        }
        public int GetNextKey()
        {
            if (this.Size() == 0)
                return 1;
            return this.GetList().Max(x => x.CodeRechisha) + 1;

        }
        public void DeleteRow(int code)
        {
            Rechishas rech= this.Find(code);
            if (rech != null)
            {
               rech.dr.Delete();
                this.Update();
            }
        }
        public void DeleteStatus(int code,int codeSapak)
        {
            Rechishas rech= this.Find(code);
            if (rech!= null)
            {
               rech.Status = true;
                this.UpdateRow(rech);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace פרויקט.BLL
{
   public class TashlumimDB:GeneralDB
    {
        public TashlumimDB() : base("Tashlumim") { }
        protected List<Tashlumim> list = new List<Tashlumim>();
        private void DataTableToList()
        {
            foreach (DataRow dr in table.Rows)
            {
                list.Add(new Tashlumim(dr));
            }
        }
        public List<Tashlumim> GetList()
        {
            list.Clear();
            DataTableToList();
            return list;
        }
        public void AddNew(Tashlumim tashlum)
        {
            tashlum.dr = table.NewRow();
            tashlum.FillDataRow();
            this.Add(tashlum.dr);
        }
        public Tashlumim Find(int code)
        {
            return this.GetList().Find(x => x.CodeTashlum == code);
        }
        public void Update()
        {
            Dal.Dal.GetInstance().Update(table.TableName);
        }
        public void UpdateRow(Tashlumim tashlum)
        {
            tashlum.FillDataRow();
            this.Update();
        }
        public int GetNextKey()
        {
            if (this.Size() == 0)
                return 1;
            return this.GetList().Max(x => x.CodeTashlum) + 1;

        }
        public void DeleteRow(int code,string id)
        {
            Tashlumim tashlum = this.Find(code);
            if (tashlum!= null)
            {
               tashlum.dr.Delete();
                this.Update();
            }
        }
    }
}

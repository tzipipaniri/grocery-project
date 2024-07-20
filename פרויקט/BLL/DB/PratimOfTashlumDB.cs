using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace פרויקט.BLL
{
   public class PratimOfTashlumDB:GeneralDB
    {
        public PratimOfTashlumDB() : base("PratimOfTashlum") { }
        protected List<PratimOfTashlum> list = new List<PratimOfTashlum>();
        private void DataTableToList()
        {
            foreach (DataRow dr in table.Rows)
            {
                list.Add(new PratimOfTashlum(dr));
            }
        }
        public List<PratimOfTashlum> GetList()
        {
            list.Clear();
            DataTableToList();
            return list;
        }
        public void AddNew(PratimOfTashlum pratimOfTash)
        {
            pratimOfTash.dr = table.NewRow();
            pratimOfTash.FillDataRow();
            this.Add(pratimOfTash.dr);
        }
        public PratimOfTashlum Find(int code)
        {
            return this.GetList().Find(x => x.CodeTashlum == code);
        }
        public void Update()
        {
            Dal.Dal.GetInstance().Update(table.TableName);
        }
        public void UpdateRow(PratimOfTashlum pratimOfTash)
        {
            pratimOfTash.FillDataRow();
            this.Update();
        }
        public int GetNextKey()
        {
            if (this.Size() == 0)
                return 1;
            return this.GetList().Max(x => x.CodeTashlum) + 1;

        }


        public void DeleteRow(int code)
        {
           PratimOfTashlum pratim = this.Find(code);
            if (pratim!= null)
            {
               pratim.dr.Delete();
                this.Update();
            }
        }
    }
}

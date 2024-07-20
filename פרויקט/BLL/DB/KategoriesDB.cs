using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using פרויקט.Gui;

namespace פרויקט.BLL
{
    public class KategoriesDB : GeneralDB
    {
        public KategoriesDB() : base("Kategories") { }
        protected List<Kategories> list = new List<Kategories>();
        private void DataTableToList()
        {
            foreach (DataRow dr in table.Rows)
                list.Add(new Kategories(dr));
        }
        public List<Kategories> GetList()
        {
            list.Clear();
            DataTableToList();
            return list;
        }
        public void AddNew(Kategories kategory)
        {
            kategory.dr = table.NewRow();
          kategory.FillDataRow();
            this.Add(kategory.dr);
        }
        public Kategories Find(int code)
        {
            return this.GetList().Find(x => x.Code == code);
        }
        public void Update()
        {
            Dal.Dal.GetInstance().Update(table.TableName);
        }
        public void UpdateRow(Kategories kategory)
        {
            kategory.FillDataRow();
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
            Kategories kategory= this.Find(code);
            if (kategory != null)
            {
                kategory.dr.Delete();
                this.Update();
            }
        }
    }
}

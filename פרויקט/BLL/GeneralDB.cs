using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace פרויקט.BLL
{
   public class GeneralDB
    {
        protected DataTable table;
        public GeneralDB(string tableName)
        {
            Dal.Dal.GetInstance().AddTable(tableName);
            table = Dal.Dal.GetInstance().GetTable(tableName);
        }
        public int Size()
        {
            return table.Rows.Count;
        }
        public bool IsEmpty()
        {
            return table.Rows.Count == 0;
        }
        public virtual void Save()
        {
            Dal.Dal.GetInstance().Update(table.TableName);
        }
        public void Add(DataRow dr)
        {
            table.Rows.Add(dr);
            this.Save();
        }

        public DataTable GetTable()
        {
            return this.table;
        }
        public void Update()
        {
            Dal.Dal.GetInstance().Update(table.TableName);
        }
       
    }
}

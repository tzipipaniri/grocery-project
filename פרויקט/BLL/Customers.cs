using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using פרויקט.Dal;

namespace פרויקט.BLL
{
  public  class Customers
    {
        public DataRow dr;
        private string idCustomer;
        private string firstName;
        private string lastName;
        private string street;
        private int city;
        private string numOfHouse;
        private double chovCustomer;
        private bool status;

        public Customers()
        {
        }
        public Customers(DataRow dr)
        {
            this.dr = dr;
            this.idCustomer = dr["idCustomer"].ToString();
            this.firstName = dr["firstName"].ToString();
            this.lastName = dr["lastName"].ToString();
            this.street = dr["street"].ToString();
            this.city =Convert.ToInt32( dr["city"]);
            this.numOfHouse = dr["numOfHouse"].ToString();
            this.chovCustomer =Convert.ToDouble( dr["chovCustomer"]);
            this.status =Convert.ToBoolean( dr["status"]);
        }
        public void FillDataRow()
        {
            dr["idCustomer"] = idCustomer;
            dr["firstName"] = firstName;
            dr["lastName"] = lastName;
            dr["street"] = street;
            dr["city"] = city;
            dr["numOfHouse"] = numOfHouse;
            dr["chovCustomer"] = chovCustomer;
            dr["status"] = status;
        }
        public override string ToString()
        {
            return firstName+" "+lastName;
        }

        public Customers(string idCustomer,
            string firstName, string lastName, string street, int city, string numOfHouse, double chovCustomer, bool status)
        {
            this.idCustomer = idCustomer;
            this.firstName = firstName;
            this.lastName = lastName;
            this.street = street;
            this.city = city;
            this.numOfHouse = numOfHouse;
            this.chovCustomer = chovCustomer;
            this.status = status;
        }

        public string IdCustomer { get => idCustomer; set { if (!Utilies.ValidateUtil.LegalId(value)) throw new Exception("ת.ז. לא תקינה"); idCustomer = value; } }
        public string FirstName { get => firstName; set { if ((!Utilies.ValidateUtil.IsEnglish(value) && (!Utilies.ValidateUtil.IsHebrew(value)))) throw new Exception("יש להזין אותיות בלבד"); if (value.Length <2) throw new Exception("יש לכתוב שם תקין"); firstName = value; } }
        public string LastName { get => lastName; set { if ((!Utilies.ValidateUtil.IsEnglish(value) && (!Utilies.ValidateUtil.IsHebrew(value)))) throw new Exception("יש להזין אותיות בלבד"); if (value.Length <2) throw new Exception("יש לכתוב שם משפחה תקינה"); lastName = value; } }
        public string Street { get => street; set { if ((!Utilies.ValidateUtil.IsEnglish(value) && (!Utilies.ValidateUtil.IsHebrew(value)))) throw new Exception("יש להזין אותיות בלבד"); if (value.Length <2) throw new Exception("יש לכתוב רח' תקין"); street = value; } }
        public int City { get => city; set => city = value; }
        public string NumOfHouse { get => numOfHouse; set { if (!Utilies.ValidateUtil.IsNum(value)) throw new Exception("יש להזין מספרים בלבד"); numOfHouse = value; } }
        public double ChovCustomer { get => chovCustomer; set => chovCustomer = value; }
        public bool Status { get => status; set => status = value; }
        public Customers ThisCustomers()
        {
            CustomersDB tblCust = new CustomersDB();
            return tblCust.Find(this.idCustomer);
        }
        public Cities ThisCities()
        {
            CitiesDB tblCities = new CitiesDB();
            return tblCities.Find(this.city);
        }
    }
}

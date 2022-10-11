using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingProject.Class
{
    public class Customer
    {

        #region Attributes

        public int id { get; set; }
        public string firstName { get; set; }

        public string familyName { get; set; }
        public string codeMelli { get; set; }

        public string phone_number { get; set; }

        public bool blacklisted_customer { get; set; }

        public bool cstDelete { get; set; }



        #endregion

        #region Associations

        public List<Main> main { get; set; } = new List<Main>();

        public List<Car> cars { get; set; } = new List<Car>();




        #endregion

    }

    public class dlCustomer
    {


        

        public Customer register(Customer customer)
        {

            Database db = new Database();

            db.customerTable.Add(customer);

            db.SaveChanges();

            return customer;

        }

        /// <summary>
        /// this method is a read all method
        /// </summary>
        /// <returns> it returns a list of Cars </returns>
        public List<Customer> read()   // READALL()
        {
            Database db = new Database();

            var q = from i in db.customerTable where i.cstDelete == false select i;

            return q.ToList();
        }


        public Customer read(int id) // SearchbyID()
        {

            Database db = new Database();

            var q = from i in db.customerTable where i.id == id && i.cstDelete == false select i;

            return q.Single();

        }


        public List<Customer> read(string search)
        {

            Database db = new Database();

            var q = from i in db.customerTable where i.firstName.Contains(search) || i.familyName.Contains(search) || i.codeMelli == search || i.phone_number == search && i.cstDelete == false select i;

            return q.ToList();

        }


        public void update(int id, Customer newCustomer)
        {
            Database db = new Database();

            var q = from i in db.customerTable where i.id.Equals(id) && i.cstDelete == false select i;

            if (q.Count() == 1)
            {

                Customer customer = new Customer();

                customer = q.Single();

                customer.firstName = newCustomer.firstName;
                customer.familyName = newCustomer.familyName;
                customer.codeMelli = newCustomer.codeMelli;
                customer.phone_number = newCustomer.phone_number;

                db.SaveChanges();


            }

        }


        public void delete(int id)
        {

            Database db = new Database();

            var q = from i in db.customerTable where i.id == id && i.cstDelete == false select i;

            if (q.Count() == 1)
            {

                Customer customer = new Customer();

                customer = q.Single();

                customer.cstDelete = true;

                db.SaveChanges();
            }

        }



    }
}

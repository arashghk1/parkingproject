using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingProject.Class
{
    public class Rates
    {
        #region Attributes
        public int id { get; set; }

        public string rateType { get; set; }

        public double price { get; set; }

        public string description { get; set; }

        public bool delete { get; set; }

        #endregion



        #region Associations

        public List<Main> main { get; set; } = new List<Main>();



        #endregion



    }

    public class dlRates
    {
       

        public Rates register(Rates rates)
        {

            Database db = new Database();

            db.ratesTable.Add(rates);

            db.SaveChanges();

            return rates;

        }

        /// <summary>
        /// this method is a read all method
        /// </summary>
        /// <returns> it returns a list of Cars </returns>
        public List<Rates> read()   // READALL()
        {
            Database db = new Database();

            var q = from i in db.ratesTable where i.delete == false select i;

            return q.ToList();
        }


        public Rates read(int id) // SearchbyID()
        {

            Database db = new Database();

            var q = from i in db.ratesTable where i.id == id && i.delete == false select i;

            return q.Single();

        }


        public List<Rates> read(string search)
        {

            Database db = new Database();

            var q = from i in db.ratesTable where i.rateType == search || i.price.ToString() == search || i.description == search && i.delete == false select i;

            return q.ToList();

        }


        public void update(int id, Rates newRates)
        {
            Database db = new Database();

            var q = from i in db.ratesTable where i.id.Equals(id) select i;

            if (q.Count() == 1)
            {

                Rates rates = new Rates();

                rates = q.Single();


                rates.rateType = newRates.rateType;
                rates.price = newRates.price;
                rates.description = newRates.description;


                db.SaveChanges();


            }

        }


        public void delete(int id)
        {

            Database db = new Database();

            var q = from i in db.ratesTable where i.id == id  select i;

            if (q.Count() == 1)
            {

                Rates rates = new Rates();

                rates = q.Single();

                rates.delete = true;

                db.SaveChanges();
            }

        }


    }
}

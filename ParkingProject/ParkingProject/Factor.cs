using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingProject.Class
{
    public class Factor
    {
        #region Attributes

        public int id { get; set; }

        public DateTime time_spent_in_parking { get; set; }


        private double _totalAmount;
        public double totalAmount 
        {
            get
            {
                return _totalAmount;
            }
            set
            {
                _totalAmount = value;
            } 
        }

        public int cars_remaining_in_parking { get; set; }

        public bool deleteFactor { get; set; }


        #endregion

        #region Associations

        public List<Main> main { get; set; } = new List<Main>();

        #endregion

    }

    public class dlFinancial
    {
        public Factor register(Factor financial)
        {

            Database db = new Database();

            db.financialTable.Add(financial);

            db.SaveChanges();

            return financial;

        }

        /// <summary>
        /// this method is a read all method
        /// </summary>
        /// <returns> it returns a list of Cars </returns>
        public List<Factor> read()   // READALL()
        {
            Database db = new Database();

            var q = from i in db.financialTable where i.deleteFactor == false select i;

            return q.ToList();
        }


        public Factor read(int id) // SearchbyID()
        {

            Database db = new Database();

            var q = from i in db.financialTable where i.id == id && i.deleteFactor == false select i;

            return q.Single();

        }


        public List<Factor> read(string search)
        {

            Database db = new Database();

            var q = from i in db.financialTable where i.time_spent_in_parking.ToString() == search || i.totalAmount.ToString() == search || i.cars_remaining_in_parking.ToString() == search && i.deleteFactor == false select i;

            return q.ToList();

        }


        public void update(int id, Factor financial)
        {
            Database db = new Database();

            var q = from i in db.financialTable where i.id.Equals(id) && i.deleteFactor == false select i;

            if (q.Count() == 1)
            {

                Factor fin = new Factor();

                fin.time_spent_in_parking = financial.time_spent_in_parking;
                fin.totalAmount = financial.totalAmount;
                fin.cars_remaining_in_parking = financial.cars_remaining_in_parking;


                db.SaveChanges();


            }

        }


        public void delete(int id)
        {

            Database db = new Database();

            var q = from i in db.financialTable where i.id == id && i.deleteFactor == false select i;

            if (q.Count() == 1)
            {

                Factor financial = new Factor();

                financial = q.Single();

                financial.deleteFactor = true;

                db.SaveChanges();
            }

        }


    }
}

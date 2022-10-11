using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingProject
{
    public class Main
    {

        public int id { get; set; }

        public Int64 invoice_number { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public Class.Customer customer { get; set; }
        public Class.Rates rate { get; set; }
        public Class.Parking parking { get; set; }
        public Class.Factor factor { get; set; }
        public bool invoice_flag { get; set; }



    }

    public class dlMain
    {
        

        public Main register(Main main)
        {

            Database db = new Database();

            db.mainTable.Add(main);

            db.SaveChanges();

            return main;

        }

        /// <summary>
        /// this method is a read all method
        /// </summary>
        /// <returns> it returns a list of Cars </returns>
        public List<Main> read()   // READALL()
        {
            Database db = new Database();

            var q = from i in db.mainTable select i;

            return q.ToList();
        }


        
        public List<Main> read(string search)
        {

            Database db = new Database();

            var q = from i in db.mainTable where i.invoice_number.ToString() == search select i;

            return q.ToList();

        }


        


    }

}

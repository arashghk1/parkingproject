using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingProject.Class
{
    public class Parking
    {

        #region Attributes
        public enum typeOfParking
        {
            public_parking = 1,private_parking = 2, organizational_parking = 3 
        }

        public int id { get; set; }

        public string name { get; set; }

        public typeOfParking type { get; set; }


        private int _capacity;
        public int capacity 
        {
            get
            {
                return _capacity;
            }
            set
            {
                if (_capacity <= 500)
                {
                    _capacity = value;
                }
                
            } 
        }

        public string operatingHours  { get; set; }

        public string number { get; set; }

        public string address { get; set; }

        public string description { get; set; }

        public bool deleteParking { get; set; }

        #endregion


        #region Associations

        public List<Employee> employees { get; set; } = new List<Employee>();

        public List<SystemUser> systemusers { get; set; } = new List<SystemUser>();

        public List<Main> main { get; set; } = new List<Main>();



        #endregion

    }

    public class dlParking
    {
        public bool exist(Parking parking)
        {
            Database db = new Database();

            var q = db.parkingTable.Any(i => i.name == parking.name && i.number == parking.number);

            return q;
        }

        public Parking register(Parking parking)
        {

            Database db = new Database();

            db.parkingTable.Add(parking);

            db.SaveChanges();

            return parking;

        }

        /// <summary>
        /// this method is a read all method
        /// </summary>
        /// <returns> it returns a list of Cars </returns>
        public List<Parking> read()   // READALL()
        {
            Database db = new Database();

            var q = from i in db.parkingTable where i.deleteParking == false select i;

            return q.ToList();
        }


        public Parking read(int id) // SearchbyID()
        {

            Database db = new Database();

            var q = from i in db.parkingTable where i.id == id && i.deleteParking == false select i;

            return q.Single();

        }


        public List<Parking> read(string search)
        {

            Database db = new Database();

            var q = from i in db.parkingTable where i.name == search || i.type.ToString() == search || i.capacity.ToString() == search || i.operatingHours == search || i.number == search || i.address == search && i.deleteParking == false select i;

            return q.ToList();

        }


        public void update(int id, Parking newParking)
        {
            Database db = new Database();

            var q = from i in db.parkingTable where i.id.Equals(id) && i.deleteParking == false select i;

            if (q.Count() == 1)
            {

                Parking parking = new Parking();

                parking = q.Single();


                parking.name = newParking.name;
                parking.type = newParking.type;
                parking.capacity = newParking.capacity;
                parking.operatingHours = newParking.operatingHours;
                parking.number = newParking.number;
                parking.address = newParking.address;


                db.SaveChanges();


            }

        }


        public void delete(int id)
        {

            Database db = new Database();

            var q = from i in db.parkingTable where i.id == id && i.deleteParking == false select i;

            if (q.Count() == 1)
            {

                Parking parking = new Parking();

                parking = q.Single();

                parking.deleteParking = true;

                db.SaveChanges();
            }

        }


    }
}

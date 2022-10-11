using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingProject.Class
{
    public sealed class Car
    {

        public enum typeCar
        {
            RegularCar, Motorcycle, Trucks
        }

        #region Attributes
        public int id { get; set; }

        public string name { get; set; }    

        public typeCar type { get; set; }

        public string  color { get; set; }

        public string plate_number { get; set; }

        public bool deleteCar { get; set; }

        #endregion


        #region Associations

        public Customer customer { get; set; }


        #endregion

    }

    public class dlCar 
    {


        

        public Car register(Car car)
        {

            Database db = new Database();

            db.carTable.Add(car);

            db.SaveChanges();

            return car;

        }

        /// <summary>
        /// this method is a read all method
        /// </summary>
        /// <returns> it returns a list of Cars </returns>
        public List<Car> read()   // READALL()
        {
            Database db = new Database();

            var q = from i in db.carTable where i.deleteCar == false select i;

            return q.ToList();
        }


        public Car read(int id) // SearchbyID()
        {

            Database db = new Database();

            var q = from i in db.carTable where i.id == id && i.deleteCar == false select i;

            return q.Single();

        }


        public List<Car> read(string search)
        {

            Database db = new Database();

            var q = from i in db.carTable where i.name.Contains(search) || i.type.ToString().Contains(search) || i.color.Contains(search) || i.plate_number == search && i.deleteCar == false select i;

            return q.ToList();

        }


        public void update(int id, Car newCar)
        {
            Database db = new Database();

            var q = from i in db.carTable where i.id.Equals(id) && i.deleteCar == false select i;

            if (q.Count() == 1)
            {

                Car car = new Car();

                car = q.Single();

                car.name = newCar.name;
                car.type = newCar.type;
                car.color = newCar.color;
                car.plate_number = newCar.plate_number;

                db.SaveChanges();


            }

        }


        public void delete(int id)
        {

            Database db = new Database();

            var q = from i in db.carTable where i.id == id && i.deleteCar == false select i;

            if (q.Count() == 1)
            {

                Car car = new Car();

                car = q.Single();

                car.deleteCar = true;

                db.SaveChanges();
            }

        }

       
    }
}

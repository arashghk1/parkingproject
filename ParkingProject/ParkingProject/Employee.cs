using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingProject.Class
{
    public sealed class Employee
    {

        #region Attributes
        public enum typeOfRole
        {
            regular_employee = 1, manager_of_parking = 2, owner_of_parking = 3
        }

        public int id { get; set; }
        public string firstName { get; set; }

        public string familyName { get; set; }
        public typeOfRole type { get; set; }

        public Int64 employee_ID { get; set; }

        public byte age { get; set; }

        public string codeMelli { get; set; }

        public double salary_Monthly { get; set; }

        public bool empDelete { get; set; }


        #endregion



        #region Associations

        public Parking parking { get; set; }

        #endregion



    }

    public class dlEmployee 
    {
        public bool exist(Employee employee)
        {
            Database db = new Database();

            var q = db.employeeTable.Any(i => i.firstName == employee.firstName && i.familyName == employee.familyName && i.codeMelli == employee.codeMelli);

            return q;
        }

        public Employee register(Employee employee)
        {

            Database db = new Database();

            db.employeeTable.Add(employee);

            db.SaveChanges();

            return employee;

        }

        /// <summary>
        /// this method is a read all method
        /// </summary>
        /// <returns> it returns a list of Cars </returns>
        public List<Employee> read()   // READALL()
        {
            Database db = new Database();

            var q = from i in db.employeeTable where i.empDelete == false select i;

            return q.ToList();
        }


        public Employee read(int id) // SearchbyID()
        {

            Database db = new Database();

            var q = from i in db.employeeTable where i.id == id && i.empDelete == false select i;

            return q.Single();

        }


        public List<Employee> read(string search)
        {

            Database db = new Database();

            var q = from i in db.employeeTable where i.firstName.Contains(search) || i.familyName.Contains(search) || i.type.ToString() == search || i.employee_ID == Convert.ToInt32(search) || i.age == Convert.ToByte(search) || i.codeMelli == search || i.salary_Monthly == Convert.ToDouble(search)  && i.empDelete == false select i;

            return q.ToList();

        }


        public void update(int id, Employee newEmployee)
        {
            Database db = new Database();

            var q = from i in db.employeeTable where i.id.Equals(id) && i.empDelete == false select i;

            if (q.Count() == 1)
            {

                Employee emp = new Employee();

                emp = q.Single();

                emp.firstName = newEmployee.firstName;
                emp.familyName = newEmployee.familyName;
                emp.type = newEmployee.type;
                emp.employee_ID = newEmployee.employee_ID;
                emp.age = newEmployee.age;
                emp.codeMelli = newEmployee.codeMelli;
                emp.salary_Monthly = newEmployee.salary_Monthly;

                db.SaveChanges();


            }

        }


        public void delete(int id)
        {

            Database db = new Database();

            var q = from i in db.employeeTable where i.id == id && i.empDelete == false select i;

            if (q.Count() == 1)
            {

                Employee employee = new Employee();

                employee = q.Single();

                employee.empDelete = true;

                db.SaveChanges();
            }

        }



    }
}

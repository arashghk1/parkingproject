using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ParkingProject.Class;

namespace ParkingProject
{
    public class Database : DbContext
    {

        public Database() : base("name = myconnection") { }

        public DbSet<Car> carTable { get; set; }

        public DbSet<Customer> customerTable { get; set; }

        public DbSet<Employee> employeeTable { get; set; }

        public DbSet<Factor> financialTable { get; set; }

        public DbSet<Main> mainTable { get; set; }

        public DbSet<Parking> parkingTable { get; set; }

        public DbSet<Permission> permissionTable { get; set; }

        public DbSet<Rates> ratesTable { get; set; }

        public DbSet<SystemUser> systemuserTable { get; set; }




    }
}

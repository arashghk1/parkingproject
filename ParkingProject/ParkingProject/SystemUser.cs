using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingProject.Class
{
    public sealed class SystemUser
    {
        #region Attributes
        public enum typeOfRoleSystem
        {
            regular_user = 1, admin = 2

        }

        public int id { get; set; }
        public string fullName { get; set; }
        public typeOfRoleSystem typeUser { get; set; }

        private string _username;
        public string username
        {
            get
            {
                return _username;
            }
            set
            {
                if (value.Length > 5)
                {
                    _username = value;
                }

            }
        }

        private string _password { get; set; }
        public string password
        {
            get
            {
                return _password;
            }
            set
            {
                if (value.Length > 5)
                {
                    _password = value;
                }
            }
        }

        public bool sysDelete { get; set; }



        #endregion


        #region Associations

        public Permission permission { get; set; }

        public Parking parking { get; set; }

        #endregion


    }

    public class dlSystemUser
    {
        public bool exist(SystemUser systemuser)
        {
            Database db = new Database();

            var q = db.systemuserTable.Any(i => i.username == systemuser.username && i.password == systemuser.username && i.typeUser == systemuser.typeUser && i.sysDelete == false);

            return q;
        }


        public byte login(string username, string password)
        {
            Database db = new Database();

            if(db.systemuserTable.Count() == 0)
            {
                return 0;
            }
            else 
            {
               
                if(db.systemuserTable.Any(i => i.username == username && i.password == password))
                {
                    return 1;
                }
                else
                {
                    return 2;
                }

            }

        }

        public SystemUser register(SystemUser systemuser)
        {

            Database db = new Database();

            db.systemuserTable.Add(systemuser);

            db.SaveChanges();

            return systemuser;

        }

        /// <summary>
        /// this method is a read all method
        /// </summary>
        /// <returns> it returns a list of Cars </returns>
        public List<SystemUser> read()   // READALL()
        {
            Database db = new Database();

            var q = from i in db.systemuserTable where i.sysDelete == false select i;

            return q.ToList();
        }


        public SystemUser read(int id) // SearchbyID()
        {

            Database db = new Database();

            var q = from i in db.systemuserTable where i.id == id && i.sysDelete == false select i;

            return q.Single();

        }


        public List<SystemUser> read(string search)
        {

            Database db = new Database();

            var q = from i in db.systemuserTable where i.username == search || i.password == search || i.typeUser.ToString() == search && i.sysDelete == false select i;

            return q.ToList();

        }


        public void update(int id, SystemUser newSystemUser)
        {
            Database db = new Database();

            var q = from i in db.systemuserTable where i.id.Equals(id) && i.sysDelete == false select i;

            if (q.Count() == 1)
            {

                SystemUser systemuser = new SystemUser();

                systemuser = q.Single();

                systemuser.username = newSystemUser.username;
                systemuser.password = newSystemUser.password;
                systemuser.typeUser = newSystemUser.typeUser;

                db.SaveChanges();


            }

        }


        public void delete(int id)
        {

            Database db = new Database();

            var q = from i in db.systemuserTable where i.id == id && i.sysDelete == false select i;

            if (q.Count() == 1)
            {

                SystemUser systemuser = new SystemUser();

                systemuser = q.Single();

                systemuser.sysDelete = true;

                db.SaveChanges();
            }

        }

    }
}

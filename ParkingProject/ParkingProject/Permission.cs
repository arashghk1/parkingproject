using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingProject.Class
{
    public class Permission
    {
        #region Attributes
        public int id { get; set; }

        public bool owner { get; set; }

        public bool admin { get; set; }

        public bool regular_user { get; set; }

        public bool deletePermission { get; set; }
        #endregion

        #region Associations

        public List<SystemUser> systemUsers { get; set; } = new List<SystemUser>();



        #endregion

    }


}

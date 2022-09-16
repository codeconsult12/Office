using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace SmartDeviceProject1.DBClasses
{
    public class User
    {

        public String USERID
        {
            get;
            set;
        }
        public String PASSWORD
        {
            get;
            set;
        }

       
    }

    public class UserRights
    {

        public String HHTUserRoleCode
        {
            get;
            set;
        }
        public String TransactionType
        {
            get;
            set;
        }

       
    }

}

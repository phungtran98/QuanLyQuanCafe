using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQuanCaffe.DAO
{
    class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
           private set { instance = value; }
        }

        private AccountDAO() { }

        public bool Login(string user, string pass)
        {
            return false;
        }




    }
}

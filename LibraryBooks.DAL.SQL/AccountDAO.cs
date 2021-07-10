using LibraryBooks.DAL.Interfaces;
using LibraryBooks.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooks.DAL.SQL
{
    public class AccountDAO : IAccount
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public void Create(string login, string password, User userInfo)
        {
            throw new NotImplementedException();
        }

        public void Delete(int idAccount)
        {
            throw new NotImplementedException();
        }

        public bool IsAuthenticated(AuthData authData)
        {
            throw new NotImplementedException();
        }
    }
}

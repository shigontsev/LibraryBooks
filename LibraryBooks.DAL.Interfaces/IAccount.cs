using LibraryBooks.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooks.DAL.Interfaces
{
    public interface IAccount
    {
        void Create(string login, string password, User userInfo);

        void Delete(int idAccount);

        bool IsAuthenticated(AuthData authData);

    }
}

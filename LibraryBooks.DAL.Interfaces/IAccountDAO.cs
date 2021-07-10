using LibraryBooks.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooks.DAL.Interfaces
{
    public interface IAccountDAO
    {
        void Create(string login, string password, User userInfo);

        void Delete(int id);

        bool IsAuthentication(string login, string password);

        IEnumerable<AuthData> GetLogins();

        AuthData GetAuthDataByLogin(string login);

    }
}

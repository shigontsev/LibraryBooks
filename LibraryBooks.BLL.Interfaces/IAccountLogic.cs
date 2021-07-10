using LibraryBooks.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooks.BLL.Interfaces
{
    public interface IAccountLogic
    {
        void Create(string login, string password, User userInfo);

        void Delete(int id);

        bool IsAuthentication(string login, string password);
    }
}

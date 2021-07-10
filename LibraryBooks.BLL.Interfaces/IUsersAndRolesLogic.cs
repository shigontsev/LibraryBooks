using LibraryBooks.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooks.BLL.Interfaces
{
    public interface IUsersAndRolesLogic
    {
        IEnumerable<UserAndRole> GetAll();

        UserAndRole GetByLogin(string login);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryBooks.Entities;

namespace LibraryBooks.DAL.Interfaces
{
    public interface IUsersAndRolesDAO
    {
        IEnumerable<UserAndRole> GetAll();

        UserAndRole GetByLogin(string login);
    }
}

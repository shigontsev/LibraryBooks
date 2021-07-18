using System.Collections.Generic;
using LibraryBooks.Entities;

namespace LibraryBooks.DAL.Interfaces
{
    public interface IUsersAndRolesDAO
    {
        IEnumerable<UserAndRole> GetAll();

        UserAndRole GetByLogin(string login);
    }
}

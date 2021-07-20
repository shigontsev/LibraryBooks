using LibraryBooks.Entities;
using System.Collections.Generic;

namespace LibraryBooks.BLL.Interfaces
{
    public interface IUsersAndRolesLogic
    {
        IEnumerable<UserAndRole> GetAll();

        UserAndRole GetByLogin(string login);
    }
}

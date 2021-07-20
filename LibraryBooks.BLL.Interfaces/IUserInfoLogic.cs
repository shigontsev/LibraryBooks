using LibraryBooks.Entities;
using System.Collections.Generic;

namespace LibraryBooks.BLL.Interfaces
{
    public interface IUserInfoLogic
    {
        IEnumerable<User> GetAll();

        User GetById(int id);

        void Edit(User user);
    }
}

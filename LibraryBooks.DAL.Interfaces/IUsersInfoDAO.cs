using LibraryBooks.Entities;
using System.Collections.Generic;

namespace LibraryBooks.DAL.Interfaces
{
    public interface IUserInfoDAO
    {
        IEnumerable<User> GetAll();

        User GetById(int id);

        void Edit(User user);
    }
}

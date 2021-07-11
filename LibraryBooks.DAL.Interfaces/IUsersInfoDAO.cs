using LibraryBooks.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooks.DAL.Interfaces
{
    public interface IUserInfoDAO
    {
        IEnumerable<User> GetAll();

        User GetById(int id);

        void Edit(User user);
    }
}

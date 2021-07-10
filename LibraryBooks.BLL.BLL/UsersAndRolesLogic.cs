using LibraryBooks.BLL.Interfaces;
using LibraryBooks.DAL.Interfaces;
using LibraryBooks.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooks.BLL.BLL
{
    public class UsersAndRolesLogic : IUsersAndRolesLogic
    {
        private IUsersAndRolesDAO _usersAndRolestDAO;

        public UsersAndRolesLogic(IUsersAndRolesDAO usersAndRolestDAO)
        {
            _usersAndRolestDAO = usersAndRolestDAO;
        }

        public IEnumerable<UserAndRole> GetAll()
        {
            return _usersAndRolestDAO.GetAll();
        }

        public UserAndRole GetByLogin(string login)
        {
            return _usersAndRolestDAO.GetByLogin(login);
        }
    }
}

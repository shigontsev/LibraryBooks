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
    public class UserInfoLogic : IUserInfoLogic
    {
        private IUserInfoDAO _userInfoDAO;

        public UserInfoLogic(IUserInfoDAO userInfoDAO)
        {
            _userInfoDAO = userInfoDAO;
        }

        public void Edit(User user)
        {
            _userInfoDAO.Edit(user);
        }

        public IEnumerable<User> GetAll()
        {
            return _userInfoDAO.GetAll();
        }

        public User GetById(int id)
        {
            return _userInfoDAO.GetById(id);
        }
    }
}

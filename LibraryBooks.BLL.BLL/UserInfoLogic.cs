using LibraryBooks.BLL.Interfaces;
using LibraryBooks.DAL.Interfaces;
using LibraryBooks.Entities;
using System.Collections.Generic;

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

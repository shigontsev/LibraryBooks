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
    public class AccountLogic : IAccountLogic
    {
        private IAccountDAO _accountDAO;

        public AccountLogic(IAccountDAO accountDAO)
        {
            _accountDAO = accountDAO;
        }

        public void Create(string login, string password, User userInfo)
        {
            _accountDAO.Create(login, password, userInfo);
        }

        public void Delete(int id)
        {
            _accountDAO.Delete(id);
        }

        public bool IsAuthentication(string login, string password)
        {
            return _accountDAO.IsAuthentication(login, password);
        }
    }
}

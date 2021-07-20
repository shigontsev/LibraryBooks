﻿using LibraryBooks.BLL.Interfaces;
using LibraryBooks.DAL.Interfaces;
using LibraryBooks.Entities;

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

        public bool Exist(string login)
        {
            return _accountDAO.Exist(login);
        }

        public AuthData GetAuthDataByLogin(string login)
        {
            return _accountDAO.GetAuthDataByLogin(login);
        }

        public bool IsAuthentication(string login, string password)
        {
            return _accountDAO.IsAuthentication(login, password);
        }
    }
}

using LibraryBooks.BLL.Interfaces;
using LibraryBooks.DAL.Interfaces;
using LibraryBooks.Entities;
using System.Collections.Generic;

namespace LibraryBooks.BLL.BLL
{
    public class UsersAndBooksLogic : IUsersAndBooksLogic
    {
        IUsersAndBooksDAO _usersAndBooksDAO;

        public UsersAndBooksLogic(IUsersAndBooksDAO usersAndBooksDAO)
        {
            _usersAndBooksDAO = usersAndBooksDAO;
        }

        public bool Exist(int userId, int bookId)
        {
            return _usersAndBooksDAO.Exist(userId, bookId);
        }

        public bool ExistByBookId(int bookId)
        {
            return _usersAndBooksDAO.ExistByBookId(bookId);
        }

        public bool ExistByUserId(int userId)
        {
            return _usersAndBooksDAO.ExistByUserId(userId);
        }

        public IEnumerable<Book> GetBooksByUserId(int userId)
        {
            return _usersAndBooksDAO.GetBooksByUserId(userId);
        }

        public IEnumerable<Book> GetBooksUnAvailableByUserId(int userId)
        {
            return _usersAndBooksDAO.GetBooksUnAvailableByUserId(userId);
        }

        public IEnumerable<User> GetUsersByBookId(int bookId)
        {
            return _usersAndBooksDAO.GetUsersByBookId(bookId);
        }

        public IEnumerable<User> GetUsersUnAvailableByBookId(int bookId)
        {
            return _usersAndBooksDAO.GetUsersUnAvailableByBookId(bookId);
        }

        public void GiveBookToUser(int bookId, int userId)
        {
            _usersAndBooksDAO.GiveBookToUser(bookId, userId);
        }

        public void ReturnBookByUser(int bookId, int userId)
        {
            _usersAndBooksDAO.ReturnBookByUser(bookId, userId);
        }
    }
}

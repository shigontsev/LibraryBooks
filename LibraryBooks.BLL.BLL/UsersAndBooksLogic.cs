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

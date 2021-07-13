using LibraryBooks.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooks.DAL.Interfaces
{
    public interface IUsersAndBooksDAO
    {
        IEnumerable<Book> GetBooksByUserId(int userId);

        IEnumerable<User> GetUsersByBookId(int bookId);

        IEnumerable<Book> GetBooksUnAvailableByUserId(int userId);

        IEnumerable<User> GetUsersUnAvailableByBookId(int bookId);

        bool Exist(int userId, int bookId);

        bool ExistByUserId(int userId);

        bool ExistByBookId(int bookId);

        void GiveBookToUser(int bookId, int userId);

        void ReturnBookByUser(int bookId, int userId);
    }
}

using LibraryBooks.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooks.BLL.Interfaces
{
    public interface IUsersAndBooksLogic
    {
        IEnumerable<Book> GetBooksByUserId(int userId);

        IEnumerable<User> GetUsersByBookId(int bookId);

        IEnumerable<Book> GetBooksUnAvailableByUserId(int userId);

        IEnumerable<User> GetUsersUnAvailableByBookId(int bookId);

        bool Exist(int userId, int bookId);

        void GiveBookToUser(int bookId, int userId);

        void ReturnBookByUser(int bookId, int userId);
    }
}

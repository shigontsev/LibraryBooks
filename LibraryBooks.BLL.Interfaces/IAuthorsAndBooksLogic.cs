using LibraryBooks.Entities;
using System.Collections.Generic;

namespace LibraryBooks.BLL.Interfaces
{
    public interface IAuthorsAndBooksLogic
    {
        IEnumerable<Book> GetBooksByAuthorId(int authorId);

        bool ExistBooks(int authorId);
    }
}

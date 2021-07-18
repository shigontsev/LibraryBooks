using LibraryBooks.Entities;
using System.Collections.Generic;

namespace LibraryBooks.DAL.Interfaces
{
    public interface IAuthorsAndBooksDAO
    {
        IEnumerable<Book> GetBooksByAuthorId(int authorId);

        bool ExistBooks(int authorId);
    }
}

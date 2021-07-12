using LibraryBooks.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooks.DAL.Interfaces
{
    public interface IAuthorsAndBooksDAO
    {
        IEnumerable<Book> GetBooksByAuthorId(int authorId);
    }
}

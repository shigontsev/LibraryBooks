using LibraryBooks.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooks.BLL.Interfaces
{
    public interface IAuthorsAndBooksLogic
    {
        IEnumerable<Book> GetBooksByAuthorId(int authorId);

        bool ExistBooks(int authorId);
    }
}

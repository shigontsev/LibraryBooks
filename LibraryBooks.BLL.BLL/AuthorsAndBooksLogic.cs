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
    public class AuthorsAndBooksLogic : IAuthorsAndBooksLogic
    {
        IAuthorsAndBooksDAO _authorsAndBooksDAO;

        public AuthorsAndBooksLogic(IAuthorsAndBooksDAO authorsAndBooksDAO)
        {
            _authorsAndBooksDAO = authorsAndBooksDAO;
        }

        public bool ExistBooks(int authorId)
        {
            return _authorsAndBooksDAO.ExistBooks(authorId);
        }

        public IEnumerable<Book> GetBooksByAuthorId(int authorId)
        {
            return _authorsAndBooksDAO.GetBooksByAuthorId(authorId);
        }
    }
}

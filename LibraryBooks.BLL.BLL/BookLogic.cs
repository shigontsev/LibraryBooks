using LibraryBooks.BLL.Interfaces;
using LibraryBooks.DAL.Interfaces;
using LibraryBooks.Entities;
using System.Collections.Generic;

namespace LibraryBooks.BLL.BLL
{
    public class BookLogic : IBookLogic
    {
        IBookDAO _bookDAO;

        public BookLogic(IBookDAO bookDAO)
        {
            _bookDAO = bookDAO;
        }

        public void Add(Book newBook)
        {
            _bookDAO.Add(newBook);
        }

        public void Delete(int id)
        {
            _bookDAO.Delete(id);
        }

        public void Edit(Book book)
        {
            _bookDAO.Edit(book);
        }

        public IEnumerable<Book> GetAll()
        {
            return _bookDAO.GetAll();
        }

        public Book GetById(int id)
        {
            return _bookDAO.GetById(id);
        }
    }
}

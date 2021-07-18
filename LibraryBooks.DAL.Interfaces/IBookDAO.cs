using LibraryBooks.Entities;
using System.Collections.Generic;

namespace LibraryBooks.DAL.Interfaces
{
    public interface IBookDAO
    {
        IEnumerable<Book> GetAll();

        void Add(Book newBook);

        void Edit(Book book);

        Book GetById(int id);

        void Delete(int id);
    }
}

using LibraryBooks.Entities;
using System.Collections.Generic;

namespace LibraryBooks.BLL.Interfaces
{
    public interface IBookLogic
    {
        IEnumerable<Book> GetAll();

        void Add(Book newBook);

        void Edit(Book book);

        Book GetById(int id);

        void Delete(int id);
    }
}

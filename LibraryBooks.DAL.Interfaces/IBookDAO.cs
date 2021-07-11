using LibraryBooks.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

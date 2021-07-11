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
    public class AuthorLogic : IAuthorLogic
    {
        IAuthorDAO _authorDAO;

        public AuthorLogic(IAuthorDAO authorDAO)
        {
            _authorDAO = authorDAO;
        }

        public void Add(string fullName)
        {
            _authorDAO.Add(fullName);
        }

        public void Delete(int id)
        {
            _authorDAO.Delete(id);
        }

        public void Edit(Author author)
        {
            _authorDAO.Edit(author);
        }

        public bool Exist(string fullName)
        {
            return _authorDAO.Exist(fullName);
        }

        public IEnumerable<Author> GetAll()
        {
            return _authorDAO.GetAll();
        }

        public Author GetByFullName(string fullName)
        {
            return _authorDAO.GetByFullName(fullName);
        }

        public Author GetById(int id)
        {
            return _authorDAO.GetById(id);
        }
    }
}

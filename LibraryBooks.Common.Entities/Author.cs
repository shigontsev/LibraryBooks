using System;

namespace LibraryBooks.Entities
{
    public class Author
    {

        public int Id { get; private set; }

        public string FullName { get; private set; }

        public Author(int id, string fullName)
        {
            Id = id;
            FullName = fullName ?? throw new ArgumentNullException(nameof(fullName),
                String.Format($"{nameof(fullName)} can't is null"));
        }

        public void Edit(string newFullName)
        {
            if (string.IsNullOrWhiteSpace(newFullName))
            {
                throw new ArgumentNullException(nameof(newFullName), String.Format($"{nameof(newFullName)} can't is empty"));
            }
            FullName = newFullName;
        }
    }
}

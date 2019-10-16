using System;

namespace ItemLibrary.Model
{
    public class Book
    {
        public string ISBN;
        public string Name;
        public string Author;
        public int PageNumbers;

        public Book(string iSBN, string name, string author, int pageNumbers)
        {
            validation(iSBN, name, author, pageNumbers);

        }
        void validation(string iSBN, string name, string author, int pageNumbers)
        {
            if (iSBN.Length == 13)
                this.ISBN = iSBN;
            else
                throw new ArgumentException("The ISBN must be 13 characters long.");
            if (name.Length > 2)
                this.Name = name;
            else
                throw new ArgumentException("The Title of a book have to be at least 2 characters long.");
            if (pageNumbers > 10 && pageNumbers <= 1000)
                this.PageNumbers = pageNumbers;
            else
                throw new ArgumentException("Pagenumbers has to be between 10 and 1000.");
            this.Author = author;
        }

    }
}


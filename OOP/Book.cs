using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Book
    {
        // these are class attributes(describing our class)
        // basically we're like creating a template or specification
        // "a book can have title, author, pages"
        public string title;
        public string author;
        public int pages;

        // constructor - same name of the class
        // we can create multiple constructor
        public Book()
        {
            Console.WriteLine("Creating a book...");
        }

        public Book(string aTitle, string aAuthor, int aPages)
        {
           title = aTitle;
           author = aAuthor;
           pages = aPages;
        }




    }
}

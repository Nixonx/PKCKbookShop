using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public class Book
    {
        public string title { get; set; }
        public double price { get; set; }
        public int pages { get; set; }
        public DateTime releaseDate { get; set; }
        public BookType type { get; set; }
        public Author author { get; set; }
        public string description { get; set; }

        #region constructors
        public Book() { }
        public Book(string title, double price, int pages, DateTime releaseDate, BookType type, Author author)
        {
            this.title = title;
            this.price = price;
            this.pages = pages;
            this.releaseDate = releaseDate;
            this.type = type;
            this.author = author;
        }
        #endregion
    }
}

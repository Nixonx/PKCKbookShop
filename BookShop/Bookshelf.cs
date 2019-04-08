using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public class Bookshelf
    {
        public string number {get; set;}
        public List<Book> books { get; set; }

        public Bookshelf() { }
        public Bookshelf(string number)
        {
            this.number = number;
            this.books = new List<Book>();
        }
        
    }
}

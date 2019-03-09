using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public class BookShopMagazine
    {
        public List<Author> authors { get; set; }
        public List<Book> books { get; set; }
        public BookShopMagazine()
        {
            books = new List<Book>();
            authors = new List<Author>();
        }
    }
}

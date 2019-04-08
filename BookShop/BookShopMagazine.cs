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
        public List<Bookshelf> bookshelf { get; set; }
        public BookShopMagazine()
        {
            bookshelf = new List<Bookshelf>();
            authors = new List<Author>();
        }
    }
}

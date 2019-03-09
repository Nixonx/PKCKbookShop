using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public class BookShopMagazine
    {
        public List<Book> books { get; set; }
        public BookShopMagazine()
        {
            books = new List<Book>();
        }
    }
}

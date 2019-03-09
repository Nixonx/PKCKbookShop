using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public class Book
    {
        string title { get; set; }
        double price { get; set; }
        int pages { get; set; }
        DateTime releaseDate { get; set; }
        BookType type { get; set; }
        Author author { get; set; }
    }
}

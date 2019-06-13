using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public enum BookType
    {
        Novel,
        Poetry,
        Horror,
        Fantasy,
        Criminal,
        Science,
        Guide,
        Children,
        History
    }
    public static class BookTypeUtils
    {
        public static List<string> getEnumsList()
        {
            List<string> result = new List<string>
            {
        "Novel",
        "Poetry",
        "Horror",
        "Fantasy",
        "Criminal",
        "Science",
        "Guide",
        "Children",
        "History"
            };
            return result;
        }
    }

}

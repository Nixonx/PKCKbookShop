using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public class Author
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string id { get; set; }

        #region constructors
        public Author() { }
        public Author(string firstName, string lastName, string id)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.id = id;
        }
        #endregion
        public string ToSting()
        {
            return firstName + " " + lastName;
        }
    }
}

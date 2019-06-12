using BookShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model
{
    public sealed class BookShopMagazineHolder
    {
        public BookShopMagazine shopMagazine { get; set; }
        private BookShopMagazineHolder()
        {
            //Author aut = new Author("Tomasz", "Przykładowy", "A44");
            //Book book = new Book("Przykład", 10.99, 10, DateTime.Now, BookType.Criminal, aut);
            //Bookshelf shelf = new Bookshelf("BC1");
            //shelf.books.Add(book);
            //shopMagazine = new BookShopMagazine();
            //shopMagazine.bookshelf = new List<Bookshelf>();
            //shopMagazine.bookshelf.Add(shelf);
            //shopMagazine.authors.Add(aut);
        }
        private static BookShopMagazineHolder _instance = null;
        public static BookShopMagazineHolder Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new BookShopMagazineHolder();

                }
                return _instance;
            }
        }
        public void Serialize(string path)
        {
            XMLutils.Serialize(shopMagazine, path);
        }
        public void Deserialize(string path)
        {
            shopMagazine = XMLutils.Deserialize(path);
        }
    }
}

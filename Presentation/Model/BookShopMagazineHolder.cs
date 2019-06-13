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
            shopMagazine = new BookShopMagazine();
            shopMagazine.authors = new List<Author>();
            shopMagazine.bookshelf = new List<Bookshelf>();
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
        public void SerializeWithXSLT(string path)
        {
            XMLutils.SerializeWithXSLT(shopMagazine, path);
        }
        public void Deserialize(string path)
        {
            shopMagazine = XMLutils.Deserialize(path);
        }
    }
}

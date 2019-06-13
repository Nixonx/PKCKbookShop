using BookShop;
using Fonet;
using Microsoft.Win32;
using System.IO;
using System.Xml.Xsl;

namespace Presentation.ViewModel
{
    public static class Cmd
    {
        #region BookCommands
        public static void OpenBookWindow()
        {
            AddBookWindow win = new AddBookWindow();
            win.Show();
        }
        public static void AddBook(BookVM sender)
        {

        }
        public static void SaveChangesBook(BookVM sender)
        {
        }
        public static void DeleteBook(BookVM sender)
        {
        }
        #endregion
        #region AuthorCommands
        public static void OpenAuthorWindow()
        {
            AddAuthorWindow win = new AddAuthorWindow();
            win.Show();
        }
        public static void AddAuthor(AuthorVM sender)
        {
            Author newAuthor = new Author(sender.firstName, sender.lastName, sender.id);
            sender.magazine.shopMagazine.authors.Add(newAuthor);
            sender.ActualizeAuthorsList();
        }
        public static void SaveChangesAuthor(AuthorVM sender)
        {
            Author newAuthor = new Author(sender.firstName, sender.lastName, sender.id);
            sender.magazine.shopMagazine.authors.Remove(sender.selectedAuthor);
            sender.magazine.shopMagazine.authors.Add(newAuthor);
            sender.ActualizeAuthorsList();
        }
        public static void DeleteAuthor(AuthorVM sender)
        {
            sender.magazine.shopMagazine.authors.Remove(sender.selectedAuthor);
            sender.ActualizeAuthorsList();
        }
        #endregion
        #region BookshelveCommands
        public static void OpenBookshelfWindow()
        {
            AddBokshelfeWindow win = new AddBokshelfeWindow();
            win.Show();
        }
        public static void AddBookshelf(BookshelfVM sender)
        {
            Bookshelf shelf = new Bookshelf(sender.bookshelfeName);
            sender.magazine.shopMagazine.bookshelf.Add(shelf);
            sender.ActualizeBookshelfList();
        }
        public static void SaveChangesBookshelf(BookshelfVM sender)
        {
            sender.selectedBookshelve.number = sender.bookshelfeName;
            sender.ActualizeBookshelfList();
        }
        public static void DeleteBookshelf(BookshelfVM sender)
        {
            sender.magazine.shopMagazine.bookshelf.Remove(sender.selectedBookshelve);
            sender.ActualizeBookshelfList();
        }
        #endregion
        #region MainWindowCommands
        public static void Refresh(MainWindowVM sender)
        {
            sender.ActualizeBooksList();
        }
        public static void GetLoadPath(MainWindowVM sender)
        {
            string path;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML files|*.xml";
            if (openFileDialog.ShowDialog() == true)
            {
                path = openFileDialog.FileName;
            }else
            {
                path = Directory.GetCurrentDirectory() + "\\serialization.xml";
            }
            sender.magazine.Deserialize(path);
            sender.ActualizeBooksList();
        }
        public static void GetSavePath(MainWindowVM sender)
        {
            string path = Directory.GetCurrentDirectory() + "\\serialization.xml";
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "XML file|*.xml";
            sfd.Title = "Save a XML File";

            if (sfd.ShowDialog() == true)
            {
                 path = sfd.FileName;
            }
            sender.magazine.Serialize(path);
            sender.ActualizeBooksList();
            return;
        }
        public static void generatePdf(MainWindowVM sender)
        {
            string testDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string xmlFilePath = Directory.GetParent(testDir).FullName + "\\Zad5\\toTransform.xml";
            string resultFOPath = Directory.GetParent(testDir).FullName + "\\Zad5\\Raport.fo";
            string resultFilePath = Directory.GetParent(testDir).FullName + "\\Zad5\\Raport.pdf";
            string transformFilePath = Directory.GetParent(testDir).FullName + "\\Zad5\\BookShopPDFTransform.xslt";

            sender.magazine.SerializeWithXSLT(xmlFilePath);

            XslCompiledTransform transform = new XslCompiledTransform();
            transform.Load(transformFilePath);
            transform.Transform(xmlFilePath, resultFOPath);
                        
            FonetDriver driver = FonetDriver.Make();
            driver.Render(resultFOPath, resultFilePath);
        }
        #endregion
    }
}

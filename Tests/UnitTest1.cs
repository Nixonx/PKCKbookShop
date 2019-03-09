using System;
using System.IO;
using BookShop;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateXMLfiles()
        {
            BookShopMagazine bookShop = new BookShopMagazine();

            Author author1 = new Author("Jan","Kowalski");
            Author author2 = new Author("Tomasz", "Sienkiewicz");
            Author author3 = new Author("Olga", "Makłowicz");
            Author author4 = new Author("Maria", "Wierzchołek");
            Author author5 = new Author("Joe", "Smith");
            Author author6 = new Author("Jessica", "Corn");
            Author author7 = new Author("Charles", "Fredrih");
            Author author8 = new Author("Ferdynad", "Kiepski");
            Author author9 = new Author("Olaf", "Ridgerd");
            Author author10 = new Author("Anna", "Kobyłka");

            bookShop.authors.Add(author1);
            bookShop.authors.Add(author2);
            bookShop.authors.Add(author3);
            bookShop.authors.Add(author4);
            bookShop.authors.Add(author5);
            bookShop.authors.Add(author6);
            bookShop.authors.Add(author7);
            bookShop.authors.Add(author8);
            bookShop.authors.Add(author9);
            bookShop.authors.Add(author10);


            Book book1 = new Book("Jak powstrzymać niedźwiedzia", 22.99, 222, new DateTime(2016, 8, 9), BookType.Guide, author1);
            Book book2 = new Book("Sposobów kilka wróbla ćwirka", 10.50, 87, new DateTime(2017, 8, 19), BookType.Children, author2);
            book2.description = "Zażuć gęślą jaźń - to zdanie zawiera wszystkie polskie znaki";
            Book book3 = new Book("Słuszna porcja kiełbasy", 40.50, 305, new DateTime(2012, 5, 1), BookType.Horror, author3);
            Book book4 = new Book("Smacznie, zdrowo i szczupło", 45.99, 288, new DateTime(2015, 5, 1), BookType.Fantasy, author3);
            Book book5 = new Book("W kręgu bieli", 45.96, 222, new DateTime(2011, 8, 9), BookType.Novel, author4);
            Book book6 = new Book("W kręgu czerni", 42.97, 223, new DateTime(2012, 9, 10), BookType.Novel, author4);
            Book book7 = new Book("W kręgu zieleni", 40.98, 224, new DateTime(2013, 10, 11), BookType.Novel, author4);
            Book book8 = new Book("Muzyka skrzypiącej podłogi", 36.99, 104, new DateTime(2005, 8, 29), BookType.Poetry, author5);
            Book book9 = new Book("Milczenie kukurydzy", 50.00, 500, new DateTime(2013, 1, 1), BookType.Criminal, author6);
            Book book10 = new Book("Atomy kryptonitu", 62.79, 432, new DateTime(2018, 12, 9), BookType.Science, author7);
            Book book11 = new Book("Moje życie z Halinką", 22.99, 222, new DateTime(2016, 8, 9), BookType.History, author8);
            Book book12 = new Book("Jak powstrzymać Paździocha", 22.99, 222, new DateTime(2016, 8, 9), BookType.Guide, author8);
            Book book13 = new Book("Jak zrobić, żaby sie nie chciało kiedy się chce", 22.99, 222, new DateTime(2016, 8, 9), BookType.Guide, author8);
            Book book14 = new Book("Sekrekt fioletowego paznokcia", 22.99, 222, new DateTime(2016, 8, 9), BookType.Criminal, author9);
            Book book15 = new Book("Ślimakowi się nie śpieszy", 22.99, 222, new DateTime(2016, 8, 9), BookType.Children, author10);

            bookShop.books.Add(book1);
            bookShop.books.Add(book2);
            bookShop.books.Add(book3);
            bookShop.books.Add(book4);
            bookShop.books.Add(book5);
            bookShop.books.Add(book6);
            bookShop.books.Add(book7);
            bookShop.books.Add(book8);
            bookShop.books.Add(book9);
            bookShop.books.Add(book10);
            bookShop.books.Add(book11);
            bookShop.books.Add(book12);
            bookShop.books.Add(book13);
            bookShop.books.Add(book14);
            bookShop.books.Add(book15);

         //   XMLutils.Serialize(bookShop, OutputFilesPath()+"\\BookShop1.xml");
        }
        private string OutputFilesPath()
        {
            string testDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            return Directory.GetParent(testDir).FullName;
        }
    }
}

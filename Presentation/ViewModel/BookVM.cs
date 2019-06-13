using BookShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Presentation.ViewModel
{
    public class BookVM : MainWindowVM
    {
        public ICommand add { get; set; }
        public ICommand delete { get; set; }
        public ICommand saveChanges { get; set; }
        public List<string> bookTypes { get; set; }
        public List<string> authorsNames { get; set; }
        public List<string> bookshelfesNames { get; set; }
        public BookVM()
        {
            saveChanges = new RelayCommand(o => Cmd.SaveChangesBook(this));
            delete = new RelayCommand(o => Cmd.DeleteBook(this));
            add = new RelayCommand(o => Cmd.AddBook(this));
            bookTypes = BookTypeUtils.getEnumsList();
            SetAuthorsList();
            SetBokshelfesList();
            ActualizeBooksList();
        }
        #region properties
        private int _selectedBookTypeId;
        public int selectedBookTypeId
        {
            get { return _selectedBookTypeId; }
            set { _selectedBookTypeId = value;
                OnPropertyChanged("selectedBookTypeId");
            }
        }
        private int _selectedAuthorId;
        public int selectedAuthorId
        {
            get { return _selectedAuthorId; }
            set
            {
                _selectedAuthorId = value;
                OnPropertyChanged("selectedAuthorId");
            }
        }
        private int _selectedBookshelfId;
        public int selectedBookshelfId
        {
            get { return _selectedBookshelfId; }
            set
            {
                _selectedBookshelfId = value;
                OnPropertyChanged("selectedBookshelfId");
            }
        }
        private Book _selectedBBook;
        public Book selectedBBook
        {
            get { return _selectedBBook; }
            set
            {
                _selectedBBook = value;
                if (value != null)
                {
                    Btitle = value.title;
                    Bprice = value.price;
                    Bpages = value.pages;
                    day = value.releaseDate.Day;
                    month = value.releaseDate.Month;
                    year = value.releaseDate.Year;
                    selectedBookTypeId = (int)value.type;
                    selectedAuthorId = FindAuhorId(value.author.ToSting());
                    selectedBookshelfId = FindBokshelfId(value);
                }
                OnPropertyChanged("seletedBBook");
            }
        }
        private string _Btitle;
        public string Btitle
        {
            get
            {
                return _Btitle;
            }
            set
            {
                _Btitle = value;
                OnPropertyChanged("Btitle");
            }
        }
        private int _BPages;
        public int Bpages
        {
            get
            {
                return _BPages;
            }
            set
            {
                _BPages = value;
                OnPropertyChanged("BPages");
            }
        }
        private double _Bprice;
        public double Bprice
        {
            get { return _Bprice; }
            set
            {
                _Bprice = value;
                OnPropertyChanged("Bprice");
            }
            
        }
        private int _day;
        public int day
        {
            get { return _day; }
            set { _day = value;
                OnPropertyChanged("day");
            }
        }
        private int _month;
        public int month
        {
            get { return _month; }
            set
            {
                _month = value;
                OnPropertyChanged("month");
            }
        }
        private int _year;
        public int year
        {
            get { return _year; }
            set
            {
                _year = value;
                OnPropertyChanged("year");
            }
        }
        #endregion
        private void SetAuthorsList()
        {
            authorsNames = new List<string>();
            foreach(Author author in magazine.shopMagazine.authors)
            {
                authorsNames.Add(author.ToSting());
            }
        }
        private int FindAuhorId(string name)
        {
            for(int i=0; i<authorsNames.Count; i++)
            {
                if (authorsNames[i] == name)
                    return i;
            }
            return -1;
        }
        private void SetBokshelfesList()
        {
            bookshelfesNames = new List<string>();
            foreach(Bookshelf bookshelf in magazine.shopMagazine.bookshelf)
            {
                bookshelfesNames.Add(bookshelf.number);
            }
        }
        private int FindBokshelfId(Book book)
        {

            for (int i = 0; i < magazine.shopMagazine.bookshelf.Count; i++)
            {
                for(int j=0; j<magazine.shopMagazine.bookshelf[i].books.Count; j++)
                {
                    if (book == magazine.shopMagazine.bookshelf[i].books[j])
                        return i;
                }
            }
            return -1;
        }
        public Book CreateBookFromParameters()
        {
            DateTime date = new DateTime(year, month, day);
            Author author = magazine.shopMagazine.authors[selectedAuthorId];
            Book result = new Book(Btitle, Bprice, Bpages, date, (BookType)selectedBookTypeId, author);
            return result;
        }
    }
}

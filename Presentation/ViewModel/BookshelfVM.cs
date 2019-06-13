using BookShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Presentation.ViewModel
{
    public class BookshelfVM : MainWindowVM
    {
        public ICommand saveChanges { get; set; }
        public ICommand delete { get; set; }
        public ICommand add { get; set; }

        public BookshelfVM()
        {
            saveChanges = new RelayCommand(o => Cmd.SaveChangesBookshelf(this));
            delete = new RelayCommand(o => Cmd.DeleteBookshelf(this));
            add = new RelayCommand(o => Cmd.AddBookshelf(this));
            ActualizeBookshelfList();
        }
        #region properties
        private string _bookshelfeName;
        public string bookshelfeName
        {
            get { return _bookshelfeName; }
            set
            {
                _bookshelfeName = value;
                OnPropertyChanged("bookshelfeName");
            }
        }
        private Bookshelf _selectedBookshelve;
        public Bookshelf selectedBookshelve
        {
            get { return _selectedBookshelve; }
            set { _selectedBookshelve = value;
                if (value != null)
                {
                bookshelfeName = value.number;
                }
                OnPropertyChanged("selectedBookshelfe");
            }
        }

        private List<Bookshelf> _bookshelves;
        public List<Bookshelf> bookshelves
        {
            get
            {
                return _bookshelves;
            }
            set
            {
                _bookshelves = value;
                OnPropertyChanged("bookshelves");
            }
        }
        #endregion
        public void ActualizeBookshelfList()
        {
            try { bookshelves = new List<Bookshelf>(magazine.shopMagazine.bookshelf); }
            catch (NullReferenceException e)
            { }
        }
    }
}

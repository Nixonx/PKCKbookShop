using BookShop;
using Microsoft.Win32;
using Presentation.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Presentation.ViewModel
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        public ICommand Load { get; set; }
        public ICommand Save { get; set; }
        public ICommand Refresh { get; set; }
        public ICommand ManageAuthor { get; set; }
        public ICommand ManageBook { get; set; }
        public ICommand ManageBookshelf { get; set; }
        public ICommand generatePdf { get; set; }
        public ObservableCollection<Book> BooksList { get; set; }


        public BookShopMagazineHolder magazine;


        public MainWindowVM()
        {
            magazine = BookShopMagazineHolder.Instance;
            Load = new RelayCommand(o => Cmd.GetLoadPath(this));
            Save = new RelayCommand(o => Cmd.GetSavePath(this));
            Refresh = new RelayCommand(o => Cmd.Refresh(this));
            generatePdf = new RelayCommand(o => Cmd.generatePdf(this));
            ManageAuthor = new RelayCommand(o => Cmd.OpenAuthorWindow());
            ManageBook = new RelayCommand(o => Cmd.OpenBookWindow());
            ManageBookshelf = new RelayCommand(o => Cmd.OpenBookshelfWindow());
            BooksList = new ObservableCollection<Book>();
        }

        public void ActualizeBooksList()
        {
            BooksList.Clear();
            foreach (Bookshelf shelf in magazine.shopMagazine.bookshelf)
            {
                foreach (Book b in shelf.books)
                {
                    BooksList.Add(b);
                }
            }
            selectedBook = BooksList[0];
        }
        private Book _selectedBook;
        public Book selectedBook
        {
            get { return _selectedBook; }
            set
            {
                _selectedBook = value;
                authorFullName = value.author.ToSting();
                OnPropertyChanged("selectedBook");
            }
        }
        private string _authorFullName;
        public string authorFullName
        {
            get { return _authorFullName; }
            set
            {
                _authorFullName = value;
                OnPropertyChanged("authorFullName");
            }
        }
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        virtual protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        #endregion      
    }
}

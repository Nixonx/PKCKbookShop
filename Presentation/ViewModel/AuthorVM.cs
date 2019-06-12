using BookShop;
using Presentation.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Presentation.ViewModel
{
    public class AuthorVM : MainWindowVM
    {
        public BookShopMagazineHolder magazine;
        public ICommand add { get; set; }
        public ICommand saveChanges { get; set; }
        public ICommand delete { get; set; }

        public AuthorVM()
        {
            magazine = BookShopMagazineHolder.Instance;
            add = new RelayCommand(o => Cmd.AddAuthor(this));
            saveChanges = new RelayCommand(o => Cmd.SaveChangesAuthor(this));
            delete = new RelayCommand(o => Cmd.DeleteAuthor(this));
            ActualizeAuthorsList();
        }
        private Author _selectedAuthor;
        public Author selectedAuthor
        {
            get { return _selectedAuthor; }
            set
            {
                _selectedAuthor = value;
                if (value == null)
                {
                    firstName = "";
                    lastName = "";
                    id = "";
                }
                else
                {
                firstName = value.firstName;
                lastName = value.lastName;
                id = value.id;
                }

                OnPropertyChanged("selectedAuthor");
            }
        }
        private string _firstName;
        public string firstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged("firstName");
            }
        }
        private string _lastName;
        public string lastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged("lastName");
            }
        }
        private string _id;
        public string id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("id");
            }
        }
        private List<Author> _authorsList;
        public List<Author> authorsList
        {
            get
            {
                return _authorsList;
            }
            set
            {
                _authorsList = value;
                OnPropertyChanged("authorsList");
            }
        }
        public void ActualizeAuthorsList()
        {
            authorsList = new List<Author>(magazine.shopMagazine.authors);
        }
    }
}

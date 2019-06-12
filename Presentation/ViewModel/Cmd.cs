using BookShop;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Presentation.ViewModel
{
    public static class Cmd
    {
        public static void OpenAddAuthorWindow()
        {
            AddAuthorWindow win = new AddAuthorWindow();
            win.Show();
        }
        public static void OpenAddBookWindow()
        {
            AddBookWindow win = new AddBookWindow();
            win.Show();
        }
        public  static void OpenAddBokshelfWindow()
        {
            AddBokshelfeWindow win = new AddBokshelfeWindow();
            win.Show();
        }
        public static void Show(MainWindowVM sender)
        {
            sender.selectedBook = sender.BooksList[3];
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
    }
}

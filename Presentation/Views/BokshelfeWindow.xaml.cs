﻿using Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Presentation
{
    /// <summary>
    /// Logika interakcji dla klasy AddBokshelfeWindow.xaml
    /// </summary>
    public partial class AddBokshelfeWindow : Window
    {
        public AddBokshelfeWindow()
        {
            DataContext = new BookshelfVM();
            InitializeComponent();
        }
    }
}

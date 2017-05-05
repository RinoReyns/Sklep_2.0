﻿using System.Collections.ObjectModel;
using System.Windows;


namespace ProjectShop
{
    
    public partial class MainWindow : Window
    {
        public MainWindow() 
        {
            InitializeComponent();
            Frame1.NavigationService.Navigate(new Page1(new ObservableCollection<Product>()));
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = ExitWindow.Exit();
        }
        
    }
}


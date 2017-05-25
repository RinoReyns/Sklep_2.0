﻿using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProjectShop
{
   
    public partial class Page3 : Page
    {
        public ObservableCollection<Product> ProductChosenList { get; set; }
        private Control _control;
        public Person Person;

        public Page3(ObservableCollection<Product> T, Person p)
        {
            InitializeComponent();
            ProductChosenList = new ObservableCollection<Product>(T);
            _control = new Control();
            Person = new Person(p);
            this.DataContext = this;
            this.NameLabel.Content = Person.Name;
            this.SurenameLabel.Content = Person.Surename;
            this.AddressLabel.Content = Person.Address;
            this.TelephoneLabel.Content = Person.Telephone;
            this.FinalPriceLabel.Content = _control.FinalPrice(ProductChosenList);
        }

        private void FinishShopping_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PdfCreator.PDF_Creator(ProductChosenList, Person);
            }
           catch (System.IO.FileNotFoundException )
            {
                 MessageBox.Show("There is a problem with finishing order. Check if program is installed corectlly, then try to make order again.", "Order problem. ");
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show("Close PDF file firts, then make your order again", "Order problem. ");
            }
            finally
            {
                Environment.Exit(0);
            }
        }

        private void BackButton1_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Page2(ProductChosenList, Person));
        }
    }
}

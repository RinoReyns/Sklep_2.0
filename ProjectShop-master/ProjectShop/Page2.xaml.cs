using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace ProjectShop
{
    /// <summary>
    /// Strona umożliwia wporwadzenie danych użytkownika potrzebnych do zamówienia.
    /// </summary>
    public partial class Page2 : Page
    {
        /// <summary>
        /// Lista produktów wyświetlana jako kosztyk użytkownika w alikacji.
        /// </summary>
        public ObservableCollection<Product> ProductChosenList { get; set; }
        /// <summary>
        /// Obiekt klasy osoba, który przechowuje dane użytkownika potrzebne do zamówienia.
        /// </summary>
        public Person Person;

        /// <summary>
        /// Kontruktor klasy Page2
        /// </summary>
        /// <param name="T"> Lista produktów wybranych przez użytkownika.</param>
        /// <param name="p"> Dane użytkownika</param>
        public Page2(ObservableCollection<Product> T, Person p)
        {
            InitializeComponent();
            ProductChosenList = new ObservableCollection<Product>(T);
            Person = new Person(p);
            this.NameTextBox.Text = Person.Name;
            this.SurenameTextBox.Text = Person.Surename;
            this.AddressTextBox.Text = Person.Address;
            this.TelephoneTextBox.Text = Person.Telephone;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Page1(ProductChosenList));
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var regtele = new Regex(@"^[0-9]{5,9}$");

                if (String.IsNullOrEmpty(NameTextBox.Text) | String.IsNullOrEmpty(SurenameTextBox.Text) | String.IsNullOrEmpty(AddressTextBox.Text)
                    | String.IsNullOrEmpty(TelephoneTextBox.Text))
                {
                    throw new InvalidOperationException("One or more of fields is empty.");
                }
                else if (!regtele.IsMatch(TelephoneTextBox.Text))
                {
                    throw new InvalidOperationException("The phone number is incorrect.");
                }
                else
                {                   
                    Person.Name = NameTextBox.Text;
                    Person.Surename = SurenameTextBox.Text;
                    Person.Address = AddressTextBox.Text;
                    Person.Telephone = TelephoneTextBox.Text;
                    this.NavigationService.Navigate(new Page3(ProductChosenList, Person));
                }
            }
            catch (InvalidOperationException t)
            {
                MessageBox.Show(t.Message, "Data Error");
            }   
        }
    }
}

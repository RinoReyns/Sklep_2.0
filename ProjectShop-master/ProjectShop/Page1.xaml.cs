using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace ProjectShop
{
    /// <summary>
    /// Strona umożliwia wybór produktów przez użytkownika.
    /// </summary>
    public partial class Page1 : Page
    {
        /// <summary>
        /// Lista produktów wyświetlana jako kosztyk użytkownika w alikacji.
        /// </summary>
        public ObservableCollection<Product> ProductChosenList { get; set; }
        private Control _control = new Control();
        private List<Product> _pro = new List<Product>();

        /// <summary>
        /// Konstruktor klasy Page1
        /// </summary>
        /// <param name="T">Lista produktów wybranych przez użytkownika</param>
        public Page1(ObservableCollection<Product> T)
        {
            InitializeComponent();
            this.DataContext = this;
            ProductChosenList = new ObservableCollection<Product>(T);
            this.ChooseCategoryComboBox.ItemsSource = Enum.GetValues(typeof(Category));
            this.ChooseCategoryComboBox.SelectedIndex = 0;
            this.ChooseItemComboBox.SelectedIndex = 0;
        }
 
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
           ExitWindow.Exit(1);
        }

        private void ChooseCategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.ChooseItemComboBox.ItemsSource = Enum.GetValues(Type.GetType("ProjectShop." + this.ChooseCategoryComboBox.SelectedValue.ToString()));
        }

        private void ChooseItemComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string valueFromChooseItemComboBox = this.ChooseItemComboBox.SelectedValue.ToString();
                if (_control.Check(_pro, valueFromChooseItemComboBox) == 0)
                    _pro.Add((Product)Activator.CreateInstance(Type.GetType("ProjectShop." + valueFromChooseItemComboBox)));

                foreach (var item in _pro)
                {
                    if (0 == (String.Compare(valueFromChooseItemComboBox, item.Name)))
                    {
                        this.TextBlockMark.Text = item.Name;
                        this.TextBlockPrice.Text = item.Price.ToString();
                        this.TextBoxQuantity.Text = item.Quantity.ToString();
                        this.TextBlockProducent.Text = item.Producent;
                        this.SizeComboBox.ItemsSource = item.Size;
                        this.SizeComboBox.SelectedIndex = 0;
                        if (0 ==(String.Compare("0",item.Color)))
                        {
                            this.ColorComboBox.ItemsSource = Enum.GetValues(typeof(ColorBlack));
                            this.ColorComboBox.SelectedIndex = 0;
                        }
                        else
                        {
                            this.ColorComboBox.ItemsSource= Enum.GetValues(typeof(Color));
                            this.ColorComboBox.SelectedIndex = 1;
                        }
                    }
                }
            }
            catch (NullReferenceException)
            {
                this.ChooseItemComboBox.SelectedIndex = 0;
            }
        }

        private void AddItemButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                const int noExist = -1;
                string valueFromChooseItemComboBox = this.ChooseItemComboBox.SelectedValue.ToString();
                string valueFromColorComboBox = this.ColorComboBox.SelectedValue.ToString();
                bool? check = this.CheckBoxButton.IsChecked;
                Product item = (Product)Activator.CreateInstance(Type.GetType("ProjectShop." + valueFromChooseItemComboBox));
                item.SizeItem = this.SizeComboBox.SelectedValue.ToString();
                int existingOfElement = _control.Check(ProductChosenList, valueFromChooseItemComboBox,valueFromColorComboBox, item.SizeItem);
            

                if (noExist == existingOfElement )
                {    //// if added element doesn't excist 
                    if (check==true)
                        item.WithWarrentyElementsCounter= int.Parse(this.TextBoxQuantity.Text);
                    item.Quantity = int.Parse(this.TextBoxQuantity.Text);
                    item.Color = valueFromColorComboBox;
                    item.Price = item.Count(item.Quantity, item.Price,check);
                    ProductChosenList.Add(item);
                }
                else
                
                {   // if excists
                    if (check == true)
                        item.WithWarrentyElementsCounter = int.Parse(this.TextBoxQuantity.Text) + ProductChosenList[existingOfElement].WithWarrentyElementsCounter;
                    else
                        item.WithWarrentyElementsCounter =  ProductChosenList[existingOfElement].WithWarrentyElementsCounter;

                    item.Price = item.Count(int.Parse(this.TextBoxQuantity.Text), item.Price, check )+ ProductChosenList[existingOfElement].Price;
                    item.Quantity = int.Parse(this.TextBoxQuantity.Text) + ProductChosenList[existingOfElement].Quantity;
                    item.Color = ProductChosenList[existingOfElement].Color;
                    ProductChosenList.RemoveAt(existingOfElement);
                    ProductChosenList.Insert(existingOfElement, item);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Select qauantity be can't ordered. Change the quantity", "Add item ");
            }
        }

        private void DeleteItemButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.ProductChosenList.RemoveAt(this.ListView1.SelectedIndex);
            }
            catch (ArgumentOutOfRangeException )
            {
                MessageBox.Show("Select item that you want to delete", "Delete item ");
            }
        }

        private void NextPageButton_Click(object sender, RoutedEventArgs e)
        {  
            try
            {
                if (0==ProductChosenList.Count)
                    throw new InvalidOperationException();
                else
                    this.NavigationService.Navigate(new Page2(ProductChosenList, new Person ()));
                      
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("You haven't chose anything.", "Empty basket. ");
            }   
        }
 
    }
}

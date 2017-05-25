using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ProjectShop
{
    /// <summary>
    /// Klasa odpowiedzialna za obługę koszyka użytkownika, oraz obliczanie końcowej ceny. 
    /// </summary>
    public class Control
    {
        /// <summary>
        /// Funkcja sprawdza czy na liście produktów o takiej samej nazwie jak nazwa produktu wybranego przez użytkownika.
        /// </summary>
        /// <param name="T"> Lista wybranych produktów przez użytkownika</param>
        /// <param name="productName">Nazwa produktu wybranego przez użytkownika</param>
        /// <returns> Funkcja zwraca "1" jeżeli produkt został dodany do listy oraz "0" jeżeli istaniał już na liście.</returns>
        public int Check(List<Product> T, string productName)
        {
            foreach (var products in T)
            {
                if ((0 == (String.Compare(productName, products.Name))))
                    return 1;
            }
            return 0;
        }

        /// <summary>
        /// Funckja przeszukuję listę produktów dodanych do koszyka o takich samych parametrach jak parametry wybrane przez użytkownika. 
        /// </summary>
        /// <param name="T">Lista wybranych produktów przez użytkownika</param>
        /// <param name="productName">Nazwa produktu</param>
        /// <param name="productColor">Kolor produktu</param>
        /// <param name="productSize">Rozmiar produktu</param>
        /// <returns>Zwraca indeks elementu o takich samych parametrach jak te, które wybrał użytkownik. W przeciwnym razie zwraca
        /// wartość, która jest interpretowana jako brak takiego produktu na liście.</returns>
        public int Check(ObservableCollection<Product> T, string productName, string productColor, string productSize)
        {
            foreach (var products in T)
            {
                if ((0 == (String.Compare(productName, products.Name))) & (0 == (String.Compare(productColor, products.Color))) & 0 == (String.Compare(productSize, products.SizeItem)))
                    return (T.IndexOf(products));
            }
            return -1;
        }
        /// <summary>
        /// Funkcja oblicza sumaryczną cenę wszystkich wybranych produktów, która jest wyświetlana w końcowym zamówieniu oraz jest używana przy wydruku
        /// zamówienia do pliku PDF.
        /// </summary>
        /// <param name="T">Lista produktów w koszyku użytkownika.</param>
        /// <returns> Sumaryczna cena podana jakos "string" </returns>
        public string FinalPrice(ObservableCollection<Product> T)
        {
            double price = 0;
            foreach (var item in T)
            {
                price += item.Price;
            }
            return price.ToString();
        }
    }
        
    
}    




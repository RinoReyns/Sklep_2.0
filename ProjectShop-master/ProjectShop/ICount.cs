namespace ProjectShop
{
    /// <summary>
    /// Interfejst definiujący strukturę funkcji Count
    /// </summary>
    interface ICount
    {
        /// <summary>
        /// Funkcja obliczająca cenę w zależności od liości produktów oraz wymagań związanych z gwarancją.
        /// </summary>
        /// <param name="quantity">Liczba produktów.</param>
        /// <param name="price">Cena jednostkowa produktu.</param>
        /// <param name="checkbox">Parametr mówiący o wymaganiu gwarancji przez użytkownika dla konkretnego produktu.</param>
        /// <returns> Funkcja zwraca obliczoną wersję produktów.</returns>
        double Count(int quantity, double price, bool? checkbox);
    }
}

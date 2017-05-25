using System.Windows;

namespace ProjectShop
{
    /// <summary>
    /// Klasa odpowiedzialna za zamykanięcie aplikacji przy pomocy "krzyżyka" na górnym pasku aplikacji oraz przyciskiem "Koniec". Podczas zamykania
    /// pokazywane jest również okno interakacji z użytkownikiem. Gdy zamknięcie okna odbywa się przy pomocy przysisku "Koniec", kolejno zamykana
    ///  jest strona oraz całe okno aplikacji. Algorytm działania funkcji zapobiega podwójnemu potwierdzaniu zamknięcia okna w przypadku interakcji 
    /// przy użyciu przycisku "Koniec".
    /// </summary>
    public static class ExitWindow
    {
        private static int OnlyOneExitMessage { get; set; } = 0;
        /// <summary>
        /// Funkcja odpowiedzialna za zamykanie aplikacji zgodnie z opisem umieszczonym w opisie klasy.
        /// </summary>
        /// <param name="i">Wartość zmiennej zapobiega podwójnemu zapytaniu użytkownika o zakmnięcie okna w przypadku interakcji z aplikacją 
        /// za pomocą przycisku "Koniec". Zmienna domyślnie ma wartość 0, lecz gdy użytkownik potwierdzi zamkniecie aplikacji zmienna przyjmuje wartość 1.</param>
        /// <returns> Funkcja zwraca wartość boolowską, True lub False, w zalezności od tego czy użytkownik potwierdzi zamknięcie aplikacji.</returns>
        public static bool Exit(int i = 0)
        {
            if (OnlyOneExitMessage == 0)
            {
                OnlyOneExitMessage = i;
                MessageBoxResult result = MessageBox.Show("Do you really want to end your shopping without order?", "Exit", MessageBoxButton.YesNo, 
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    Application.Current.Shutdown();
                }
                else if (result == MessageBoxResult.No)
                {
                    OnlyOneExitMessage = 0;
                    return true;
                }
            }
            return false;
        }
    }
}

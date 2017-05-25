using System.Collections.ObjectModel;
using System.Windows;


namespace ProjectShop
{
    /// <summary>
    /// Główne okno projektu, w który zmienane są  kolejne strony w zależności od interakcji użytkownika.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Kontruktor klasy, który tworzy okno programu oraz przeności użytkownika na stronę startową.
        /// </summary>
        public MainWindow() 
        {
            InitializeComponent();
            Frame1.NavigationService.Navigate(new Page1(new ObservableCollection<Product>()));
        }

        /// <summary>
        /// Funkcja, który jest wywoływana przy przyciśnięciu "krzyżyka" na górnym pasku okna.
        /// </summary>
        /// <param name="sender"> Zmienna, w której jest przekazywana klasa obiektu wywołującego funkcję. </param>
        /// <param name="close"> Parametr odpowiedzialny za potwierdzenie zamknięcia okana. </param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs close)
        {
            close.Cancel = ExitWindow.Exit();
        }
        
    }
}


using System.Windows;

namespace ProjectShop
{
    public static class ExitWindow
    {
        private static int OnlyOneExitMessage { get; set; } = 0;
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

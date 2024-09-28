using mgok2.Helpers;
using mgok2.Pages.Authentification;
using System.Windows;

namespace mgok2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Navigation.nav = FrameMain;
            FrameMain.Navigate(new Authentification());

        }
    }
}

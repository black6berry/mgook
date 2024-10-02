using mgok2.Helpers;
using mgok2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace mgok2.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для PageMainAdmin.xaml
    /// </summary>
    public partial class PageMainAdmin : Page
    {
        private List<User> users = new List<User>();

        public PageMainAdmin()
        {
            InitializeComponent();
            LoadUser();
        }
        // Ф-я загрузки пользователей из БД
        public void LoadUser()
        {
            try
            {
                var data = Connecting.conn.User.ToList();

                if (data != null)
                {
                    users = data;
                    DgUser.ItemsSource = users.ToList();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка", $"Ошибка получения данных пользователей {ex}", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}

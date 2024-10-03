using mgok2.Helpers;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace mgok2.Windows.Admin
{
    /// <summary>
    /// Логика взаимодействия для AdminAddUser.xaml
    /// </summary>
    public partial class AdminAddUser : Window
    {
        public AdminAddUser()
        {
            InitializeComponent();
            GetRolesUser();
        }

        private void GetRolesUser()
        {
            var data = Connecting.conn.Role.ToList();

            if (data != null)
            {
                CmbRole.ItemsSource = data;
            }
            else
            {
                MessageBox.Show("В таблице не найдено ни одной роли", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

using mgok2.Helpers;
using mgok2.Pages.Admin;
using mgok2.Pages.Student;
using mgok2.Pages.Teacher;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace mgok2.Pages.Authentification
{
    /// <summary>
    /// Логика взаимодействия для Authentification.xaml
    /// </summary>
    public partial class Authentification : Page
    {
        private string Login = "";
        private string Password = "";

        public Authentification()
        {
            InitializeComponent();

        }

        // Кнопка обработки Авторизации
        private void BtnAuth_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            
            try
            {
                if (TxbLogin.Text != null && TxbLogin.Text != "")
                {
                    if (PsbPasswd.Password != null)
                    {
                        Login = TxbLogin.Text;
                        Password = PsbPasswd.Password;

                        var result = Connecting.conn.User.FirstOrDefault(x => x.Phone == Login && x.Password == Password);

                        if (result != null)
                        {
                            switch (result.Role.Name)
                            {
                                case "Admin":
                                    Navigation.nav.Navigate(new PageMainAdmin());
                                    break;

                                case "Студент":
                                    Navigation.nav.Navigate(new PageMainStudent());
                                    break;

                                case "Преподаватель":
                                    Navigation.nav.Navigate(new PageMainTeacher());
                                    break;
                            }

                            MessageBox.Show($"Вы успешно авторизовались как {result.Role.Name}");
                        }
                        else
                        {
                            MessageBox.Show("Пользователь не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Логин не может быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Пароль не может быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            catch
            {
                MessageBox.Show("Ошибка в обработке данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            
        }
    }
}

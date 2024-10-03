using mgok2.Helpers;
using mgok2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
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
        private string Firstname;
        private string Lastname;
        private string Patronymic;
        private int RoleId;
        private string Phone;
        private string Email;
        private string Password;

        public AdminAddUser()
        {
            InitializeComponent();
            GetRolesUser();

        }

        private void GetRolesUser()
        {
            try
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
            catch(Exception ex) 
            {
                MessageBox.Show($"Ошибка - {ex}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnAddUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Firstname = TxbFirstname.Text;
                Lastname = TxbLastname.Text;
                Patronymic = TxbPatronymic.Text;
                RoleId = (int)CmbRole.SelectedValue;
                Phone = TxbPhone.Text;
                Email = TxbEmail.Text;
                Password = PswdUser.Password;

                if (!grid.GetChildren<TextBox>().Any(txb => string.IsNullOrEmpty(txb.Text)))
                {
                    if (!grid.GetChildren<PasswordBox>().Any(psswdb => string.IsNullOrEmpty(psswdb.Password)))
                    {
                        if(!grid.GetChildren<ComboBox>().Any(cmb => string.IsNullOrEmpty(CmbRole.Text)))
                        {
                            if (Password == PswdUserRepeat.Password)
                            {

                                User newUser = new User()
                                {
                                    Firstname = Firstname,
                                    Lastname = Lastname,
                                    Patronymic = Patronymic,
                                    RoleId = RoleId,
                                    Phone = Phone,
                                    Email = Email,
                                    Password = Password,
                                };

                                Connecting.conn.User.Add(newUser);
                                Connecting.conn.SaveChanges();
                                int idNewUser = newUser.Id;

                                MessageBox.Show($"Добавлен новый пользователь {Lastname} {Firstname} {Patronymic} {idNewUser}", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                            else
                            {
                                MessageBox.Show($"Пароли не совпадают", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show($"Заполнены не все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Поле пароль не может быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"Не все поля заполнены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании пользователя {ex}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}

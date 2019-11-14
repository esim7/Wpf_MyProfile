using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf_Homew3
{
    /// <summary>
    /// Логика взаимодействия для SignUp.xaml
    /// </summary>
    public partial class SignUp : Page
    {
        public MainWindow mainWindow;

        public SignUp(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void signUp_Click(object sender, RoutedEventArgs e)
        {
            if(textBox_Login_reg.Text.Length == 0)
            {
                MessageBox.Show("Введите логин");
            }
            else if(passwordBox_Password_reg.Password.Length == 0)
            {
                MessageBox.Show("Введите пароль");
            }
            else if (passwordBox_Password_Copy.Password.Length == 0)
            {
                MessageBox.Show("Повторите пароль");
            }
            else if (passwordBox_Password_reg.Password != passwordBox_Password_Copy.Password)
            {
                MessageBox.Show("Введены неверные пароли");
            }
            else
            {
                using (var context = new Context())
                {
                    var user = new User
                    {
                        Login = textBox_Login_reg.Text,
                        Password = passwordBox_Password_reg.Password
                    };
                    context.Add(user);
                    context.SaveChanges();
                    MessageBox.Show("Вы успешно зерегистрировали аккаунт");
                }
                mainWindow.OpenPage(Pages.login);
            }
        }

        private void cancel_reg_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(Pages.login);
        }

    }
}

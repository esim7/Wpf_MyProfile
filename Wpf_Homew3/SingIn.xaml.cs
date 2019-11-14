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
using System.Linq;

namespace Wpf_Homew3
{
    /// <summary>
    /// Логика взаимодействия для SingIn.xaml
    /// </summary>
    public partial class SingIn : Page
    {
        public MainWindow mainWindow;
        public SingIn(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void signIn_Click(object sender, RoutedEventArgs e)
        {
            if(textBox_Login.Text.Length == 0 || passwordBox_Password.Password.Length == 0)
            {
                MessageBox.Show("Введите логин и пароль");
            }
            using (var context = new Context())
            {
                var user = context.Users.FirstOrDefault(x => x.Login == textBox_Login.Text && x.Password == passwordBox_Password.Password);
                if(user == null)
                {
                    MessageBox.Show("Пользователь не существует");
                }
                else
                {
                    mainWindow.MainUser = user;
                    mainWindow.OpenPage(Pages.myCabinet);
                }   
            }
        }

        private void signUp_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(Pages.registration);
        }
    }
}

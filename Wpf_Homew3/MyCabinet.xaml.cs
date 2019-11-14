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
using Microsoft.Win32;

namespace Wpf_Homew3
{
    /// <summary>
    /// Логика взаимодействия для MyCabinet.xaml
    /// </summary>
    public partial class MyCabinet : Page
    {
        public MainWindow mainWindow;
        private Context context = new Context();

        public MyCabinet(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            ShowMyInfo();
        }
        public void ShowMyInfo()
        {
            login.Content += " " + this.mainWindow.MainUser.Login;
            fullname.Content += " " + this.mainWindow.MainUser.FullName;
            age.Content += " " + this.mainWindow.MainUser.Age;
            phonenumber.Content += " " + this.mainWindow.MainUser.PhoneNumber;
            if(this.mainWindow.MainUser.Status != null)
            {
                Uri uri = new Uri(this.mainWindow.MainUser.Status, UriKind.Absolute);
                ImageSource imgSource = new BitmapImage(uri);
                myPhoto.Source = imgSource;
            }
        }

        private void accept_changes(object sender, RoutedEventArgs e)
        {
            var user = context.Users.SingleOrDefault(x => x.Id == this.mainWindow.MainUser.Id && x.Password == this.mainWindow.MainUser.Password);
            if(newName.Text != string.Empty)
            {
                user.FullName = newName.Text;
            }
            else if(newAge.Text != string.Empty)
            {
                user.Age = int.Parse(newAge.Text);
            }
            else if (newPhoneNumber.Text != string.Empty)
            {
                user.PhoneNumber = newPhoneNumber.Text;
            }
            user.Status = myPhoto.Source.ToString();
            mainWindow.MainUser = user;
            context.SaveChanges();
            mainWindow.OpenPage(Pages.myCabinet);
        }

        private void changePhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.ShowDialog();
            string imagePath = openFile.FileName;
            Uri uri = new Uri(imagePath, UriKind.Absolute);
            ImageSource imgSource = new BitmapImage(uri);
            myPhoto.Source = imgSource;
        }
    }
}

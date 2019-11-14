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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf_Homew3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public User MainUser { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            OpenPage(Pages.login);
        }

        public void OpenPage(Pages page)
        {
            if(page == Pages.login)
            {
                frame.Navigate(new SingIn(this));
            }
            else if(page == Pages.registration)
            {
                frame.Navigate(new SignUp(this));
            }
            else if (page == Pages.myCabinet)
            {
                frame.Navigate(new MyCabinet(this));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace POCA
{
    public partial class RegisterPage : PhoneApplicationPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void gobackButton_Click(object sender, RoutedEventArgs e)
        {
            MainPage mynewPage = new MainPage(); //newPage is the name of the newPage.xaml file
            this.Content = mynewPage;
        }
    }
}
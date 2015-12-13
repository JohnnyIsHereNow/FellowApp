using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using POCA.Resources;
using POCA.Control_Layer;
namespace POCA
{
    public partial class MainPage : PhoneApplicationPage
    {
        private UserController uc = new UserController();
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            ServiceReference1.RandomNumbersClient cl = new ServiceReference1.RandomNumbersClient();
            String s = cl.GetNumberAsync();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Trying to connect to database: ");
            //click here when you want to login
            if (!txtUsername.Text.Equals("") && !txtPassword.Password.Equals(""))
            {
                MessageBox.Show(uc.LogInUser(txtUsername.Text, txtPassword.Password).ToString());
                if (uc.LogInUser(txtUsername.Text, txtPassword.Password))
                {
                    RegisterPage mynewPage = new RegisterPage(); //newPage is the name of the newPage.xaml file
                    this.Content = mynewPage;
                }
        //try to connect to the database, check the info and then change the screen
            }
            else
            {
                MessageBox.Show("Username or password invalid.");
            }
        }
        public void Callback(IAsyncResult r)
        {
            System.Windows.Deployment.Current.Dispatcher.BeginInvoke(() => {
                MessageBox.Show("Asdsad");
            });
           
        }
        private void signUpButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterPage mynewPage = new RegisterPage(); //newPage is the name of the newPage.xaml file
            this.Content = mynewPage;
        }

        private void recoverButton_Click(object sender, RoutedEventArgs e)
        {
            //recover password and/or username
        }

        private void TextBox_TextChanged(object sender, RoutedEventArgs e)
        {

        }
        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}
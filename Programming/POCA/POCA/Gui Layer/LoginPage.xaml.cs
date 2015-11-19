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
using POCA.Gui_Layer;

namespace POCA
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            //click here when you want to login
            if(!txtUsername.Text.Equals("") && !txtPassword.Password.Equals(""))
            {
                MessageBox.Show("It works just fine. Go kill yourself now Johnny ! You should do it.");
                //try to connect to the database, check the info and then change the screen
            }
            else
            {
                MessageBox.Show("Username or password invalid.");
            }
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

        private void testButton_Click(object sender, RoutedEventArgs e)
        {
            SearchPage searchPage = new SearchPage();
            this.Content = searchPage;
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
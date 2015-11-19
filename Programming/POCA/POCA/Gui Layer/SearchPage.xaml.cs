using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace POCA.Gui_Layer
{
    public partial class SearchPage : PhoneApplicationPage
    {
        public SearchPage()
        {
            InitializeComponent();
        }

        private void SelectPassions_Click(object sender, RoutedEventArgs e)
        {
            MainPage mynewPage = new MainPage(); //newPage is the name of the newPage.xaml file
            this.Content = mynewPage;
        }

        private void AdvancedSearchButton_Click(object sender, RoutedEventArgs e)
        {
            ShowResults showResults = new ShowResults();
            this.Content = showResults;
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            ShowResults showResults = new ShowResults();
            this.Content = showResults;
        }
    }
}
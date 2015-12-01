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
    public partial class ShowResults : PhoneApplicationPage
    {
        public ShowResults()
        {
            InitializeComponent();
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            SearchPage searchPage = new SearchPage();
            this.Content = searchPage;
        }
    }
}
using Messenger.Models;
using Messenger.Sites;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Messenger.Pages
{
    public partial class AddAccountPage : Page
    {
        public static SiteListModel Model = new SiteListModel();
        public static event EventHandler ItemClicked;

        public AddAccountPage()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            Model.GetData();
            DataContext = Model;
        }

        private void SiteList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SiteList == null || SiteList.SelectedIndex < 0)
                return;

            var siteItem = SiteList.SelectedItem as SiteBase;
            SiteList.SelectedIndex = -1;
            if (siteItem == null)
                return;

            ItemClicked?.Invoke(siteItem, EventArgs.Empty);
        }

    }
}

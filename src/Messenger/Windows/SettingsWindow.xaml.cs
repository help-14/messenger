using Messenger.Pages;
using System;
using System.Windows;

namespace Messenger.Windows
{
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            WPFUI.Background.Manager.Apply(this);
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AddAccountPage());
            AddAccountPage.ItemClicked += OnNewAccountCreated;
        }

        private void OnNewAccountCreated(object? sender, EventArgs e)
        {
            AddAccountPage.ItemClicked -= OnNewAccountCreated;
            Close();
        }
    }
}

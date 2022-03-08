using Messenger.Models;
using Messenger.Pages;
using Messenger.Sites;
using Messenger.Windows;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Messenger
{
    public partial class MainWindow : Window
    {
        public static MainPageModel Model = new MainPageModel();

        public MainWindow()
        {
            WPFUI.Background.Manager.Apply(this);
            InitializeComponent();
            Loaded += OnLoaded;
        }

        #region App Event

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            Loaded -= OnLoaded;
            App.Current.Exit += OnExit;

            DataContext = Model;
            Model.GetData();

            if (Model.Tabs.Count == 0)
                Model.Tabs.Add(new Sites.ListSites());
            tabControl.SelectedIndex = 0;

            AddAccountPage.ItemClicked += OnNewAccountCreated;

            var settingButton = tabControl.Template.FindName("SettingButton", tabControl)
                as System.Windows.Controls.Button;
            if (settingButton != null)
                settingButton.Click += (_, _) => { Model?.SaveData(); new SettingsWindow().Show(); };

            var addButton = tabControl.Template.FindName("AddButton", tabControl)
                as System.Windows.Controls.Button;
            if (addButton != null)
                addButton.Click += (_, _) => { AddNewTab(); };
        }

        private void AddNewTab()
        {
            if (Model?.Tabs != null)
                Model.Tabs.Add(new Sites.ListSites());
            tabControl.SelectedIndex = tabControl.Items.Count - 1;
        }

        private void OnNewAccountCreated(object? sender, EventArgs e)
        {
            var site = sender as Sites.SiteBase;

            if (site == null || Model?.Tabs == null ||
                tabControl?.Items == null || tabControl.Items.Count == 0)
                return;

            var selectedIndex = tabControl.SelectedIndex;
            if (selectedIndex >= 0)
            {
                Model.Tabs.RemoveAt(selectedIndex);
                Model.Tabs.Insert(selectedIndex, site);
                tabControl.SelectedIndex = selectedIndex;
            }
            else
            {
                Model.Tabs.Add(site);
                tabControl.SelectedIndex = tabControl.Items.Count - 1;
            }
        }

        private void OnExit(object sender, ExitEventArgs e)
        {
            Model?.SaveData();
            if (RootTitleBar != null) RootTitleBar.UseNotifyIcon = false;
        }

        #endregion

        #region TrayMenu

        private void TrayMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            if (sender is not MenuItem menuItem) return;

            string tag = menuItem.Tag as string ?? String.Empty;

            System.Diagnostics.Debug.WriteLine("Menu item clicked: " + tag);
        }

        private void RootTitleBar_OnNotifyIconClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Notify Icon clicked");
        }

        #endregion

        #region Tab Events

        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TabItem_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (!(e.Source is TabItem tabItem))
            {
                return;
            }

            if (Mouse.PrimaryDevice.LeftButton == MouseButtonState.Pressed)
            {
                DragDrop.DoDragDrop(tabItem, tabItem, DragDropEffects.All);
            }
        }

        private void TabItem_Drop(object sender, DragEventArgs e)
        {
            var targetSite = (e.Source as TabItem)?.DataContext as SiteBase;
            var sourceSite = (e.Data.GetData(typeof(TabItem)) as TabItem)?.DataContext as SiteBase;
            if (targetSite != null && sourceSite != null && Model?.Tabs != null)
            {
                var targetIndex = Model.Tabs.IndexOf(targetSite);
                Model.Tabs.Remove(sourceSite);
                Model.Tabs.Insert(targetIndex, sourceSite);

                if (tabControl != null)
                    tabControl.SelectedIndex = targetIndex;
            }
        }

        #endregion

    }
}

using System;
using System.Windows;

namespace Messenger
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            WPFUI.Theme.Watcher.Start(true, true);
        }

    }
}

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Linq;
using Messenger.Db;
using Messenger.Db.Models;
using Messenger.Sites;
using PropertyChanged.SourceGenerator;
using System;

namespace Messenger.Models
{
    public partial class MainPageModel
    {

        [Notify]
        public ObservableCollection<SiteBase> Tabs { get; set; }

        public void GetData()
        {
            Tabs = new ObservableCollection<SiteBase>();

            var accounts = new GetSavedAccountTask().Execute() as List<Account>;
            if (accounts != null)
            {
                var supportedSites = Assembly.GetAssembly(typeof(SiteBase))
                    .GetTypes()
                    .Where(t => t.IsSubclassOf(typeof(SiteBase)))
                    .ToList();

                foreach (var accountItem in accounts)
                {
                    var site = supportedSites.FirstOrDefault(t => (Attribute.GetCustomAttribute(t, typeof(SiteNameAttribute)) as SiteNameAttribute)?.Name == accountItem.Site);
                    if (site != null)
                    {
                        var instant = Activator.CreateInstance(site) as SiteBase;
                        if (instant != null)
                        {
                            instant.LoadFrom(accountItem);
                            Tabs.Add(instant);
                        };
                    }
                }
            }
        }

        public void SaveData()
        {
            if (Tabs == null) return;
            foreach (var tab in Tabs)
            {
                if (tab.Url == null || string.IsNullOrEmpty(tab.SiteName))
                    continue;
                tab.SaveCookies();
            }
        }
    }
}

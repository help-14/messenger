using Messenger.Sites;
using PropertyChanged.SourceGenerator;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace Messenger.Models
{
    public partial class SiteListModel
    {
        [Notify]
        public ObservableCollection<SiteBase> Sites { get; set; }

        public void GetData()
        {
            var supportedSites = Assembly.GetAssembly(typeof(SiteBase))
                    .GetTypes()
                    .Where(t => t.IsSubclassOf(typeof(SiteBase)))
                    .ToList();
            Sites = new ObservableCollection<SiteBase>();

            foreach (var site in supportedSites)
            {
                var instant = Activator.CreateInstance(site) as SiteBase;
                if (instant != null
                    && instant.Url != null
                    && !string.IsNullOrEmpty(instant.SiteName))
                    Sites.Add(instant);
            }
        }

    }
}

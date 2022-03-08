
using System;
using System.Windows.Media;

namespace Messenger.Sites
{
    [SiteName("New Account")]
    internal class ListSites : SiteBase
    {
        public ListSites()
        {
            Content = new Pages.AddAccountPage();
            Title = "New Account";
        }

        public override Geometry Icon => Geometry.Parse("M19.6,2h-3.2c-0.9,0-1.6,0.7-1.6,1.6v11.2H3.6c-0.9,0-1.6,0.7-1.6,1.6v3.2c0,0.9,0.7,1.6,1.6,1.6   h11.2v11.2c0,0.9,0.7,1.6,1.6,1.6h3.2c0.9,0,1.6-0.7,1.6-1.6V21.2h11.2c0.9,0,1.6-0.7,1.6-1.6v-3.2c0-0.9-0.7-1.6-1.6-1.6H21.2V3.6   C21.2,2.7,20.5,2,19.6,2z");

        public override Uri Url => null;

        public override string[] CookieUrls => new[] { "" };
    }
}

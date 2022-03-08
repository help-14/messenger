using Microsoft.Web.WebView2.Wpf;
using System;
using System.Windows.Media;

namespace Messenger.Sites
{
    [SiteName("Android Messages")]
    public partial class AndroidMessage : SiteBase
    {
        public AndroidMessage()
        {
            Content = new WebView2 { Source = Url };
        }

        public override Uri Url => new Uri("https://messages.google.com/web/conversations");

        public override Geometry Icon => Geometry.Parse("M40 4h-32c-2.21 0-4 1.79-4 4v36l8-8h28c2.21 0 4-1.79 4-4v-24c0-2.21-1.79-4-4-4z");

        public override string[] CookieUrls => new[] { "" };

    }
}

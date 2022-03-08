using Microsoft.Web.WebView2.Wpf;
using System;
using System.Windows.Media;

namespace Messenger.Sites
{
    [SiteName("Telegram")]
    public partial class Telegram : SiteBase
    {
        public Telegram()
        {
            Content = new WebView2 { Source = Url };
        }

        public override Uri Url => new Uri("https://webz.telegram.org");

        public override Geometry Icon => Geometry.Parse("M484.689,98.231l-69.417,327.37c-5.237,23.105-18.895,28.854-38.304,17.972L271.2,365.631     l-51.034,49.086c-5.646,5.647-10.371,10.372-21.256,10.372l7.598-107.722L402.539,140.23c8.523-7.598-1.848-11.809-13.247-4.21     L146.95,288.614L42.619,255.96c-22.694-7.086-23.104-22.695,4.723-33.579L455.423,65.166     C474.316,58.081,490.85,69.375,484.689,98.231z");

        public override string[] CookieUrls => new[] { "telegram.me", "t.me" };

    }
}

using System;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using Messenger.Db;
using Messenger.Db.Models;
using Microsoft.Web.WebView2.Wpf;
using PropertyChanged.SourceGenerator;

namespace Messenger.Sites
{
    public abstract partial class SiteBase
    {
        public void LoadFrom(Account dbAccount)
        {
            DbAccount = dbAccount;
            Title = dbAccount?.Title ?? Title;
            LoadCookies();
        }

        public Account? DbAccount { get; set; }

        public abstract Geometry Icon { get; }

        [Notify]
        public Brush AccentBrush => new SolidColorBrush(Colors.Transparent);

        public abstract Uri Url { get; }

        public abstract string[] CookieUrls { get; }

        public string? SiteName
        {
            get
            {
                return (Attribute.GetCustomAttribute(this.GetType(), typeof(SiteNameAttribute)) as SiteNameAttribute)?.Name;
            }
        }

        [Notify] private string? _title;
        public string Title
        {
            get
            {
                if (string.IsNullOrEmpty(_title))
                    _title = SiteName;
                return _title;
            }
            set { _title = value; }
        }

        [Notify]
        public UIElement? Content { get; set; }

        public void Reload() { }

        private WebView2? getWebview()
        {
            return Content as WebView2;
        }

        public async void LoadCookies()
        {
            var webView = getWebview();
            if (webView == null || DbAccount == null) return;

            foreach (var cookie in DbAccount.Cookies)
            {
                if (webView.CoreWebView2 == null)
                    return;
                var ck = webView.CoreWebView2.CookieManager.CreateCookie(
                        cookie.Name, cookie.Value, cookie.Domain, cookie.Path
                    );
                webView.CoreWebView2.CookieManager.AddOrUpdateCookie(ck);
            }
        }

        public async void SaveCookies()
        {
            var webView = getWebview();
            if (webView == null) return;
            if (DbAccount == null)
            {
                DbAccount = new Account
                {
                    Site = SiteName,
                    Title = Title,
                    Cookies = new System.Collections.Generic.List<Cookie>()
                };
            }
            else
                DbAccount.Cookies.Clear();

            var allCookies = await webView.CoreWebView2.CookieManager.GetCookiesAsync(null);
            foreach (var cookieUrl in CookieUrls)
            {
                var cookies = allCookies.Where(c => c.Domain.Equals(cookieUrl)).ToList();
                foreach (var cookie in cookies)
                {
                    DbAccount.Cookies.Add(new Cookie()
                    {
                        Domain = cookie.Domain,
                        Name = cookie.Name,
                        Value = cookie.Value,
                        Path = cookie.Path,
                    });
                }
            }

            DbAccount = new AddUpdateAccountTask(DbAccount).Execute() as Account;
        }
    }

    [AttributeUsage(AttributeTargets.All)]
    public class SiteNameAttribute : Attribute
    {
        public SiteNameAttribute(string name)
        {
            this.Name = name;
        }

        public virtual string Name { get; set; }
    }
}

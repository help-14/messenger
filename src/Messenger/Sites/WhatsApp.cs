﻿using Microsoft.Web.WebView2.Wpf;
using System;
using System.Windows.Media;

namespace Messenger.Sites
{
    [SiteName("WhatsApp")]
    public partial class WhatsApp : SiteBase
    {
        public WhatsApp()
        {
            Content = new WebView2 { Source = Url };
        }

        public override Uri Url => new Uri("https://web.whatsapp.com");

        public override Geometry Icon => Geometry.Parse("M50,4L50,4C24.6,4,4,24.6,4,50c0,9.6,2.9,18.7,8.4,26.5l-8.2,18c-0.2,0.4-0.1,0.8,0.2,1.1c0.3,0.3,0.7,0.4,1.1,0.3   l19.7-7.2c7.4,4.8,16,7.3,24.8,7.3c0,0,0.1,0,0.1,0c25.4,0,46-20.6,46-46S75.4,4,50,4z M75.6,67.7c-0.3,0.8-1,1.7-1.4,2.4   c-0.9,1.2-2,2.4-3,3.2c-0.2,0.2-0.4,0.3-0.6,0.5c-0.2,0.1-0.3,0.2-0.5,0.3c-0.8,0.6-1.6,1-2.3,1.2c-0.5,0.2-1.1,0.3-1.7,0.3   c-0.2,0-0.4,0-0.5,0c-1,0-1.6-0.2-3-0.7c-1.1-0.5-2.3-1-3.6-1.5l-0.3-0.2c-1.1-0.5-2.2-1.1-3.3-1.6L55,71.3   c-1.1-0.6-2.1-1.2-3.1-1.8l-0.2-0.2c-6.9-4.3-12.7-9.5-17.7-16c-0.5-0.6-0.9-1.2-1.4-1.8c-0.2-0.3-0.4-0.6-0.6-0.9l-0.6-0.9   c-0.4-0.6-0.7-1.1-1.1-1.7c0,0-0.1-0.1-0.1-0.1c-0.3-0.6-0.7-1.1-1-1.7c0,0-0.1-0.1-0.1-0.2c-1.6-2.8-3-5.7-4-8.5   c-1.1-3-1.4-4.9-0.2-7c0.5-0.9,2.4-2.7,3.7-3.6c2.3-1.7,3.3-2.3,4.3-2.5c0.7-0.1,1.8-0.1,2.6,0.2c0.4,0.1,0.9,0.4,1.2,0.6   c1.9,1.2,6.3,6.9,7.7,9.6c1,1.8,1.2,3.2,0.9,4.3c-0.3,1.2-1,1.9-3,3.4c-0.4,0.4-0.9,0.7-1.2,1c-0.1,0.1-0.1,0.1-0.2,0.2   c0,0-0.1,0.1-0.1,0.1c-0.2,0.2-0.3,0.8-0.3,1.2c0,1,0.7,3.3,1.9,5.1c0.9,1.4,2.4,3.2,4,4.6c1.8,1.6,3.4,2.7,5.2,3.6   c2.1,1,3.4,1.3,4.1,1c0,0,0,0,0,0c0.1-0.1,0.3-0.1,0.4-0.2c0.2-0.2,0.6-0.7,1.3-1.5c1-1.3,1.5-1.8,2.3-2.2c0.2-0.1,0.5-0.2,0.7-0.3   c1.4-0.5,2.9-0.4,4.3,0.4c1,0.5,3,1.7,4.3,2.6c1.6,1.1,5.4,4.1,6,4.8c0.6,0.7,1,1.6,1,2.6C76.1,66.1,75.9,66.9,75.6,67.7z");

        public override string[] CookieUrls => new[] { "" };
    }
}

using Microsoft.Web.WebView2.Wpf;
using System;
using System.Windows.Media;

namespace Messenger.Sites
{
    [SiteName("Messenger")]
    public partial class FbMessenger : SiteBase
    {
        public FbMessenger()
        {
            Content = new WebView2 { Source = Url };
        }

        public override Uri Url => new Uri("https://www.messenger.com");

        public override Geometry Icon => Geometry.Parse("M256,0.003c-144.225,0 -256,105.645 -256,248.325c0,74.637 30.596,139.126 80.406,183.682c4.172,3.76 6.696,8.962 6.902,14.577l1.391,45.534c0.463,14.525 15.452,23.951 28.742,18.131l50.788,-22.407c4.326,-1.905 9.117,-2.266 13.649,-1.03c23.334,6.439 48.213,9.839 74.122,9.839c144.225,0 256,-105.646 256,-248.326c0,-142.68 -111.775,-248.325 -256,-248.325Zm-153.703,320.953l75.203,-119.295c11.95,-18.955 37.602,-23.694 55.527,-10.25l59.802,44.864c5.511,4.121 13.032,4.069 18.492,-0.051l80.766,-61.296c10.765,-8.19 24.879,4.739 17.616,16.174l-75.152,119.243c-11.95,18.956 -37.601,23.694 -55.526,10.251l-59.802,-44.865c-5.512,-4.121 -13.032,-4.069 -18.492,0.052l-80.818,61.347c-10.765,8.19 -24.879,-4.739 -17.616,-16.174Z");

        public override string[] CookieUrls => new[] { ".messenger.com" };

        public new Brush AccentBrush => new LinearGradientBrush()
        {
            StartPoint = new System.Windows.Point(0, 1),
            EndPoint = new System.Windows.Point(1, 0),
            GradientStops = new GradientStopCollection()
            {
                new GradientStop(Color.FromArgb(50,3,149,255), 0),
                new GradientStop(Color.FromArgb(50,255,96,116), 1)
            }
        };
    }
}

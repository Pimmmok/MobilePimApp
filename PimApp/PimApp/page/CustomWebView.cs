using Xamarin.Forms;

namespace PimApp
{
    public class CustomWebView : WebView
    {
        public static readonly BindableProperty UriProperty = BindableProperty.Create(nameof(Uri), typeof(string), typeof(CustomWebView));
       
        public string Uri
        {
            get { return (string)GetValue(UriProperty); }
            set { SetValue(UriProperty, value); }
        }
    }
}

using Android.Content;
using PimApp;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Webkit;
using System.Net;

[assembly: ExportRenderer(typeof(CustomWebView), typeof(CustomWebViewRenderer))]
namespace PimApp
{
	public class CustomWebViewRenderer: WebViewRenderer
	{
        public CustomWebViewRenderer(Context context) : base(context)
        {

        }
		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement != null)
			{
				base.OnElementChanged(e);

				if (e.NewElement != null)
				{
					var customWebView = Element as CustomWebView;
					Control.Settings.AllowUniversalAccessFromFileURLs = true;
					Control.LoadUrl(string.Format("file:///android_asset/pdfjs/web/viewer.html?file={0}", string.Format("file:///android_asset/Content/{0}", WebUtility.UrlEncode(customWebView.Uri))));
				}
			}
		}
	}

}

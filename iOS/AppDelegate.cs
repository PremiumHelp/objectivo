using System;
using System.Collections.Generic;
using System.Linq;
using Facebook.CoreKit;
using Foundation;
using UIKit;
using Syncfusion.SfCarousel.XForms.iOS;
namespace ObjectivoF.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            Rg.Plugins.Popup.Popup.Init();
            new SfCarouselRenderer();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
        public override bool OpenUrl(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
        {
            // We need to handle URLs by passing them to their own OpenUrl in order to make the SSO authentication works.
            return ApplicationDelegate.SharedInstance.OpenUrl(application, url, sourceApplication, annotation);
        }
    }
}

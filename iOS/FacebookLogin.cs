using Facebook.CoreKit;
using Facebook.LoginKit;
using Foundation;
using System.Threading.Tasks;
using UIKit;
using ObjectivoF;
using Xamarin.Forms;

using System;

[assembly: Dependency(typeof(ObjectivoF.iOS.FacebookLogin))]
namespace ObjectivoF.iOS
{
    public class FacebookLogin : ObjectivoF.IFacebookLogin
    {
        public static void Init()
        {
            
        }
        //the Getcontroller method is for the shared behaviour from IOS to all ViewControllers
        private UIViewController GetController()
        {
            var vc = UIApplication.SharedApplication.KeyWindow.RootViewController;
            while (vc.PresentedViewController != null)
                vc = vc.PresentedViewController;
            return vc;
        }

        LoginManager manager;

        public async Task<FbLoginResult> SignIn()
        {

            var tcs = new TaskCompletionSource<FbLoginResult>();
            manager = new LoginManager();

            manager.Init();
            var result = await manager.LogInWithReadPermissionsAsync(new string[] { "email", "public_profile" }, GetController());
           
            if (!result.IsCancelled)
            {
                try
                {
                    var request = new GraphRequest("/me?fields=id,name,email", null, result.Token.TokenString, null, "GET");
                    request.Start((connection, res, error) =>
                    {
                        var userInfo = res as NSDictionary;
                        var id = userInfo["id"].ToString();
                        var name = userInfo["name"].ToString();
                        var email = userInfo["email"].ToString();
                        tcs.SetResult(new FbLoginResult
                        {
                            AccessToken = result.Token.ToString(),
                            UserId = id,
                            Name = name,
                            Email = email,
                            Status = FBStatus.Success
                        });
                    });
                }
                catch { }
            }
            else if (result.IsCancelled)
            {
                tcs.SetResult(null);
            }

            return await tcs.Task;
        }

        public Task<FbLoginResult> SignOut()
        {
            var tcs = new TaskCompletionSource<FbLoginResult>();
            if (manager != null)
            {
                manager.LogOut();
                tcs.SetResult(new FbLoginResult()
                {
                    Status = FBStatus.Success,
                    Message = "Successfully Logged Out"
                });
            }
            else
            {
                tcs.SetResult(new FbLoginResult()
                {
                    Status = FBStatus.Error,
                    Message = "You are not Logged In"
                });
            }
            return tcs.Task;
        }

       
      
       
    }
}

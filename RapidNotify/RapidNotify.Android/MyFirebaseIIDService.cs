using Android.App;
using Android.Content;
using Firebase.Iid;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RapidNotify.Droid
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    public class MyFirebaseIIDService : FirebaseInstanceIdService
    {
        const string TAG = "MyFirebaseIIDService";

        /**
         * Called if InstanceID token is updated. This may occur if the security of
         * the previous token had been compromised. Note that this is called when the InstanceID token
         * is initially generated so this is where you would retrieve the token.
         */

        // [START refresh_token]
        //public static IApiProvider _apiProvider;
        //PushTokenManager _PushTokenManager = new PushTokenManager();
        public override void OnTokenRefresh()
        {
            //var intent = new Intent(this, typeof(RegistrationIntentService));
            //StartService(intent);

            // Get updated InstanceID token.
            var refreshedToken = FirebaseInstanceId.Instance.Token;

            Android.Util.Log.Debug(TAG, "Refreshed token: " + refreshedToken);

            // TODO: Implement this method to send any registration to your app's servers.
            SendRegistrationToServer(refreshedToken);
        }
        // [END refresh_token]

        /**
         * Persist token to third-party servers.
         *
         * Modify this method to associate the user's FCM InstanceID token with any server-side account
         * maintained by your application.
         */

        //public async Task<string> SetCommonValue()
        //{
        //    if (Device.OS == TargetPlatform.Android)
        //    { MiSERV_App.App.device_type_ = "android"; }
        //    if (Device.OS == TargetPlatform.iOS)
        //    { MiSERV_App.App.device_type_ = "iphone"; }
        //    DateTime CurrentDateTime = DateTime.Now;
        //    DateTime TokenExpire = new DateTime();
        //    if (MiSERV_App.Helpers.Settings.GSettingsTokenExpire != "" && MiSERV_App.Helpers.Settings.GSettingsTokenExpire != null)
        //    { TokenExpire = Convert.ToDateTime(MiSERV_App.Helpers.Settings.GSettingsTokenExpire); }
        //    if (CurrentDateTime >= TokenExpire)
        //    {
        //        await DependencyService.Get<IAuthenticator>().Authenticate();
        //    }
        //    else
        //    {
        //        MiSERV_App.App.date_ = CurrentDateTime.ToString("yyyy:MM:dd:hh:mm:ss:ffff");
        //        MiSERV_App.App.date_ = App.date_.Replace(@":", string.Empty);
        //    }
        //    string MD5_Encrypt = await DependencyService.Get<IEncryption>().MD5Encryption(MiSERV_App.App.date_);
        //    App.md5_ = MD5_Encrypt;
        //    App.access_token_ = MiSERV_App.Helpers.Settings.GSettingsAccessToken;
        //    return "0";
        //}
        void SendRegistrationToServer(string token)
        {
            try
            {
               RapidNotify.App.DeviceToken = token;
              //  await SetCommonValue();
                //if (MiSERV_App.Helpers.Settings.GSettingsLoginUserID != "" && MiSERV_App.Helpers.Settings.GSettingsLoginUserID != null)
                //{
                //    await _PushTokenManager.PushToken(new PushTokenRequest() { sendpush = "1", pushtoken = App.DeviceToken, user_id = MiSERV_App.Helpers.Settings.GSettingsLoginUserID, date = App.date_, device_type = App.device_type_, device_id = App.device_id_, version = App.App_version_, access_token = App.access_token_, md5 = App.md5_ }, (Pushobj) =>
                //    {
                //        PushTokenModel Pushobjj = Pushobj as PushTokenModel;
                //    }, (Pushresult) =>
                //    {
                //        dynamic data = JObject.Parse(Pushresult.ToString());
                //        string Errmsg = Convert.ToString(data.error.message);
                //        UserDialogs.Instance.HideLoading();
                //        UserDialogs.Instance.Alert(Errmsg, "", "OK");
                //    });
                //}
            }
            catch (Exception ex)
            {
            }
        }
    }
}
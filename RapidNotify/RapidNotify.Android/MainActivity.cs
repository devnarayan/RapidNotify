using Android.App;
using Android.Content.PM;
using Android.OS;
using Firebase.Iid;
using Java.Lang;
using System.Threading.Tasks;

namespace RapidNotify.Droid
{
    [Activity(Label = "Rapid Notify", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        const string TAG = "MainActivity";
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            if (GetString(Resource.String.google_app_id) == "1:65149015302:android:6903285b889fe9fb")
                if (Intent.Extras != null)
                {
                    foreach (var key in Intent.Extras.KeySet())
                    {
                        var value = Intent.Extras.GetString(key);
                        Android.Util.Log.Debug(TAG, "Key: {0} Value: {1}", key, value);
                    }
                }
            Task.Run(() =>
            {
                try
                {
                    var instanceID = FirebaseInstanceId.Instance;
                    instanceID.DeleteInstanceId();
                    var iid1 = instanceID.Token;
                    var iid2 = instanceID.GetToken(GetString(Resource.String.gcm_defaultSenderId), Firebase.Messaging.FirebaseMessaging.InstanceIdScope);
                    Android.Util.Log.Debug(TAG, "Iid1: {0}, iid2: {1}", iid1, iid2);
                }
                catch (Exception ex)
                {
                }
            });
            global::Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App());
        }
    }
}
using System;
using Android.App;
using Android.Content;
using Android.Util;
using Firebase.Iid;
using RapidNotify.Models;

namespace RapidNotify.Droid
{
    [Service(Exported = false)]
    class RegistrationIntentService : IntentService
    {
        // Notification topics that I subscribe to:
        static readonly string[] Topics = { "global" };
        // Create the IntentService, name the worker thread for debugging purposes:
        public RegistrationIntentService() : base("RegistrationIntentService")
        { }
        // OnHandleIntent is invoked on a worker thread:
        protected override void OnHandleIntent(Intent intent)
        {
            try
            {
                Log.Info("RegistrationIntentService", "Calling InstanceID.GetToken");
                const string TAG = "MyFirebaseIIDService";

                // Ensure that the request is atomic:
                lock (this)
                {
                    var refreshedToken = FirebaseInstanceId.Instance.Token;
                    Log.Debug(TAG, "Refreshed token: " + refreshedToken);
                    SendRegistrationToServer(refreshedToken);

                    // Request a registration token:
                    //var instanceID = FirebaseInstanceId.GetInstance().GetToken();
                    //var token = instanceID.GetToken("1:493025887176:android:ca1b9f9707761df9",
                    //    GoogleCloudMessaging.InstanceIdScope, null);

                    // Log the registration token that was returned from GCM:
                    //   Log.Info("RegistrationIntentService", "FCM Registration Token: " + token);

                    // Send to the app server (if it requires it):
                    //     SendRegistrationToAppServer(token);

                    // Subscribe to receive notifications:
                    //     SubscribeToTopics(token, Topics);
                }
            }
            catch (Exception ex)
            {
                Log.Debug("RegistrationIntentService", "Failed to get a registration token");
            }
        }

        void SendRegistrationToServer(string token)
        {
            // Add custom implementation, as needed.
            App.DeviceToken = token;
            App.DeviceType = TokenType.Android;
        }

        void SendRegistrationToAppServer(string token)
        {
            // Add custom implementation here as needed.
            //App.DeviceToken = token;
        }

        // Subscribe to topics to receive notifications from the app server:
        //void SubscribeToTopics(string token, string[] topics)
        //{
        //    foreach (var topic in topics)
        //    {
        //        var pubSub = FcmPubSub.GetInstance(this);
        //        pubSub.Subscribe(token, "/topics/" + topic, null);
        //    }
        //}
    }
}
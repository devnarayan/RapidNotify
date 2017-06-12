using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Media;
using Android.Support.V4.App;
using Firebase.Messaging;
using RapidNotify.Droid;
using System;

namespace RapidNotify.Droid
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class MyFirebaseMessagingService : FirebaseMessagingService
    {
        const string TAG = "MyFirebaseMsgService";
        //NotificationView objNotificationModel = new NotificationView();
        /**
         * Called when message is received.
         */

        // [START receive_message]
        public override void OnMessageReceived(RemoteMessage message)
        {
            // TODO(developer): Handle FCM messages here.
            // If the application is in the foreground handle both data and notification messages here.
            // Also if you intend on generating your own notifications as a result of a received FCM
            // message, here is where that should be initiated. See sendNotification method below.
            Android.Util.Log.Debug(TAG, "From: " + message.From);
            Android.Util.Log.Debug(TAG, "Notification Message Body: " + message.GetNotification().Body);
            SendNotification(message.GetNotification().Body);
        }
        // [END receive_message]

        /**
         * Create and show a simple notification containing the received FCM message.
         */
        void SendNotification(string messageBody)
        {
            //Tools.chk = true;
            //Tools.NotifyMsg = messageBody;
            try
            {
                var intent = new Intent(this, typeof(MainActivity));
                //Intent intent = new Intent(Context,);
                intent.AddFlags(ActivityFlags.ClearTop);
                var pendingIntent = PendingIntent.GetActivity(this, 0 /* Request code */, intent, PendingIntentFlags.OneShot);
                var defaultSoundUri = RingtoneManager.GetDefaultUri(RingtoneType.Notification);
                var notificationBuilder = new NotificationCompat.Builder(this)
                    .SetContentTitle("Rapid Notify")
                    .SetContentText(messageBody)
                    .SetAutoCancel(true)
                    .SetSound(defaultSoundUri)
                    .SetLights(Color.Red, 1, 1)
                    .SetContentIntent(pendingIntent);
                var notificationManager = NotificationManager.FromContext(this);
                notificationManager.Notify(0 /* ID of notification */, notificationBuilder.Build());
                //App.NotificationCount = Convert.ToString(Convert.ToInt32(App.NotificationCount) + 1);
                //Xamarin.Forms.MessagingCenter.Send<string>(App.NotificationCount, "Hi");
            }
            catch (System.Exception ex)
            {
            }
        }


    }

}

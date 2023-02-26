using Android.Content;

namespace Powiadomienia.Droid.AndroidNotification {
    [BroadcastReceiver(Enabled = true, Label = "Local Notifications Broadcast Receiver")]
    public class AlarmHandler : BroadcastReceiver {
        public override void OnReceive(Context context, Intent intent) {
            if (intent?.Extras != null) {
                string title = intent.GetStringExtra(AndroidNotification.TitleKey);
                string message = intent.GetStringExtra(AndroidNotification.MessageKey);

                AndroidNotification manager = AndroidNotification.Instance ?? new AndroidNotification();
                manager.Show(title, message);
            }
        }
    }
}

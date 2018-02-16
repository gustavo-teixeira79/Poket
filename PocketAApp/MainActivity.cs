using Android.App;
using Android.Widget;
using Android.OS;
using System.Net.Http;
using System.Text;
using System;

namespace PocketAApp
{
    [Activity(Label = "PocketAApp", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.btnLogin);
            string user = FindViewById<EditText>(Resource.Id.txtUserName).Text;
            string password = FindViewById<EditText>(Resource.Id.txtPassWord).Text;

            button.Click += delegate { Authenticate(user, password); };
        }

        public void Authenticate(string user, string password)
        {
            bool resp = false;
            TextView status = FindViewById<TextView>(Resource.Id.lblStatus);

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:62123");
                    var content = new StringContent("{\"email\":\"" + user + "\",\"password\":\"" + password + "\"}", Encoding.UTF8, "application/json");
                    client.Timeout = new TimeSpan(0, 0, 60);
                    HttpResponseMessage result = client.PostAsync("/api/user/Authenticate", content).Result;
                    if (result.IsSuccessStatusCode) resp = true;
                }
            }
            catch (Exception e)
            {
                status.Text = "Error " + e.Message;
                return;
            }

            if (resp)
                status.Text = "Valid User";
            else
                status.Text = "Invalid user or password";

        }
    }


}


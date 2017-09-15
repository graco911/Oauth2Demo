using Android.App;
using Android.Widget;
using Android.OS;
using Xamarin.Auth;
using Newtonsoft;
using System;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Oauth2Demo
{
    [Activity(Label = "Oauth2Demo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button authenticationbutton, buttonsensordata;
        TextView Status, consumptionpower,consumptionenergy, generationpower, generationenergy, netpower, netenergy;
        string clientid;
        string clientsecret;
        string constants;
        string autorizeurl;
        string redirecturl;
        string accesstokenurl;
        string userinfo;
        private string token;
        System.Threading.Timer Timer;
        public OAuth2Authenticator autenthicator { get; set; }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            Xamarin.Auth.Presenters.XamarinAndroid.AuthenticationConfiguration.Init(this, bundle);

            //clientid = "3066ba75ead5a16cee5f";
            //clientsecret = "d901d0c0665b479958db2fd6255637c0e4b46090";
            //constants = null;
            //autorizeurl = "https://github.com/login/oauth/authorize";
            //redirecturl = "https://github.com";
            //accesstokenurl = "https://github.com/login/oauth/access_token";
            //userinfo = "https://api.github.com/user";


            clientid = "5umdIT-MRoe1TkBJLeSOFQ";
            clientsecret = "Zz2hV2AsTnK8DLsDT4lNkg";
            constants = null;
            autorizeurl = "https://api.neur.io/v1/oauth2/authorize";
            redirecturl = "https://www.neur.io/";
            accesstokenurl = "https://api.neur.io/v1/oauth2/token";
            userinfo = "https://api.neur.io/v1/name";

            authenticationbutton = FindViewById<Button>(Resource.Id.buttonAuthenticationh);
            buttonsensordata = FindViewById<Button>(Resource.Id.buttonGetSensorData);
            Status = FindViewById<TextView>(Resource.Id.textViewStatus);
            consumptionpower = FindViewById<TextView>(Resource.Id.textViewConsumptionPower);
            consumptionenergy = FindViewById<TextView>(Resource.Id.textViewConsumptionEnergy);
            generationpower = FindViewById<TextView>(Resource.Id.textViewGenerationPower);
            generationenergy = FindViewById<TextView>(Resource.Id.textViewGenerationEnergy);
            netpower = FindViewById<TextView>(Resource.Id.textViewNetPower);
            netenergy = FindViewById<TextView>(Resource.Id.textViewNetEnergy);

            UpdateView();
            autenthicator = new OAuth2Authenticator
                (
                clientid,
                clientsecret,
                constants,
                new System.Uri(autorizeurl),
                new System.Uri(redirecturl),
                new System.Uri(accesstokenurl));


            autenthicator.Completed += OnAuthCompleted;

            autenthicator.Error += OnAuthError;

            authenticationbutton.Click += LaunchOAuth;

            buttonsensordata.Click += GetSensorData;
        }

        private async void UpdateView()
        {
            consumptionpower.Text = "";
            consumptionenergy.Text = "";
            generationpower.Text = "";
            generationenergy.Text = "";
            netpower.Text = "";
            netenergy.Text = "";
            while (true)
            {
                await Task.Delay(1000);
                var s = new Services();
                var datasensor = await s.GetSensorDataAsync();
                if(datasensor != null)
                {
                    consumptionpower.Text = datasensor.consumptionPower.ToString();
                    consumptionenergy.Text = datasensor.consumptionEnergy.ToString();
                    generationpower.Text = datasensor.generationPower.ToString();
                    generationenergy.Text = datasensor.generationEnergy.ToString();
                    netpower.Text = datasensor.netPower.ToString();
                    netenergy.Text = datasensor.netEnergy.ToString();
                }

            }
        }

        private void GetSensorData(object sender, EventArgs e)
        {

        }

        private void OnAuthError(object sender, AuthenticatorErrorEventArgs e)
        {
            Status.Text = e.Message;
        }

        private void LaunchOAuth(object sender, EventArgs e)
        {
            //var presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
            //presenter.Login(autenthicator);
            var ui = autenthicator.GetUI(this);
            StartActivity(ui);
        }

        private async void GetUser(Account token)
        {
            //var request = new OAuth2Request("GET", new Uri(userinfo), null, token);
            //var response = await request.GetResponseAsync();
            //if (response != null)
            //{
            //    string jsonuser = response.GetResponseText();
            //    var user = JsonConvert.DeserializeObject<User>(jsonuser);
            //    Status.Append(user.name + "\n"
            //        + user.id + "\n" +
            //        user.location + "\n" +
            //        user.organizations_url);
            var service = new Services();
            var user = await service.GetUserDataAsync();
            if (user != null)
            {

            }
        }

        private void OnAuthCompleted(object sender, AuthenticatorCompletedEventArgs e)
        {
            if (e.IsAuthenticated)
            {
                token = e.Account.Properties["access_token"];
                Status.Text = token;
                GetUser(e.Account);
            }
        }
    }
}

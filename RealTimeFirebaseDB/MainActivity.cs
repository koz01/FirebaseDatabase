using Android.App;
using Android.Widget;
using Android.OS;
using Firebase.Xamarin.Database;
using System;

namespace RealTimeFirebaseDB
{
    [Activity(Label = "RealTimeFirebaseDB", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        string FirebaseURL = "https://realtimefirebasedb.firebaseio.com/";
        protected async override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var firebase = new FirebaseClient(FirebaseURL);

            Account ac = new Account
            {
                UserID = 1,
                Name ="Kyaw Zin Oo",
                Email = "giodan.09@gmail.com"
            };

            try
            {
                var item = await firebase.Child("account").PostAsync<Account>(ac);
            }catch(Exception ex)
            {
                string str = ex.Message;
            }

            try
            {
                int d = Convert.ToInt32("kdd");

            } catch (Exception ex) {

                Exceptions except = new Exceptions
                {
                    Date = DateTime.Now,
                    ClassName = "Export DB Helper",
                    MethodName = "GetDBHelper()",
                    Exception  = ex.Message,
                };

                await firebase.Child("except").PostAsync<Exceptions>(except);
            }
        }


        public class Exceptions
        {
            public DateTime Date{ get; set; }

            public string ClassName { get; set; }

            public string MethodName { get; set; }

            public string Exception { get; set; }
        }
    }
}


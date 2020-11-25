using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Landeta_DbStorage.Droid
{
    [Activity(Label = "Landeta_DbStorage", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        
        Button access;
        EditText User, Password;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            access = FindViewById<Button>(Resource.Id.btn_entrar);
            User = FindViewById<EditText>(Resource.Id.et_user);
            Password = FindViewById<EditText>(Resource.Id.et_password);

           
            access.Click += delegate {
                Conexion con = new Conexion();
                if (con.TryConnection(this, User.Text, Password.Text))
                {
                    Toast.MakeText(this, "Conexion Exitosa!", ToastLength.Long).Show();
                }
                else
                {
                    Toast.MakeText(this, "Error!", ToastLength.Long).Show();
                }
            };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
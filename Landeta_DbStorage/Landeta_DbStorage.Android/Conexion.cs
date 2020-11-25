using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MySql.Data.MySqlClient;

namespace Landeta_DbStorage.Droid
{
    class Conexion
    {
     
		public bool TryConnection(Context context, string Usuario, string Contrasenia)
        {
            MySqlConnectionStringBuilder Builder = new MySqlConnectionStringBuilder();
            Builder.Port = 3306;
            Builder.Server = "sql10.freemysqlhosting.net"; 
            Builder.Database = "sql10378404";
            Builder.UserID = Usuario; 
            Builder.Password = Contrasenia; 
            try
            {
                MySqlConnection ms = new MySqlConnection(Builder.ToString());
                ms.Open();
                return true;
            }
            catch (Exception ex)
            {
                Toast.MakeText(context, ex.ToString(), ToastLength.Long).Show(); 
                return false;
            }
        }
    }
}
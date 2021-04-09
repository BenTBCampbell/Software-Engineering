using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fictionary.Services;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using static Xamarin.Essentials.Platform;

[assembly:Dependency(typeof(Fictionary.Droid.StatusBarService))]
namespace Fictionary.Droid
{
    public class StatusBarService : IStatusBarService
    {
        /// <summary>
        /// Sets the color of the top of the status bar
        /// </summary>
        /// <param name="color">The color to set</param>
        public void SetStatusBarColor(Color color)
        {
           CurrentActivity.Window.SetStatusBarColor(color.AddLuminosity(-0.1).ToAndroid());
        }
    }
}
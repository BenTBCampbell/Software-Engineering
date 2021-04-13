using System;
using Fictionary.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(Fictionary.iOS.StatusBarService))]
namespace Fictionary.iOS
{
    public class StatusBarService : IStatusBarService
    {
        /// <summary>
        /// Sets the color of the top of the status bar
        /// </summary>
        /// <param name="color">The color to set</param>
        public void SetStatusBarColor(Color color)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Fictionary.Services
{
    /// <summary>
    /// An interface used to set the status bar style
    /// </summary>
    public interface IStatusBarService
    {
        /// <summary>
        /// Sets the color of the status bar
        /// </summary>
        /// <param name="color">The color</param>
        void SetStatusBarColor(Xamarin.Forms.Color color);
    }
}

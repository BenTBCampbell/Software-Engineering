using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Fictionary.ViewModels
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // We only need to use this for dependency properties with a custom Set attribute
        public void RaisePropertyChanged(params string[] propertyNames)
        {
            // Notify the system for each property that has changed
            foreach (string name in propertyNames)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }

        public INavigation Navigation { get; set; }
    }
}

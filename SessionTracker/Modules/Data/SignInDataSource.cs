using SessionTracker.Modules.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SessionTracker.Modules.Data
{
    class SignInDataSource : INotifyPropertyChanged
    {
        private BindingList<SignInData> data;

        public BindingList<SignInData> Data
        {
            get => this.data;
            set
            {
                this.data = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

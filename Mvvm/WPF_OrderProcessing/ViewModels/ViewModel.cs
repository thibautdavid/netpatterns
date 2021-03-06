﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF_OrderProcessing.ViewModels
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected abstract void InitCommands();

        public ViewModel()
        {
            InitCommands();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

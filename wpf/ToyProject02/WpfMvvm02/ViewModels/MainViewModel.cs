using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace WpfMvvm02.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {

        [ObservableProperty]
        private string title;

        public MainViewModel()
        {
            title = "BookRentalShop";
        }
    }
}

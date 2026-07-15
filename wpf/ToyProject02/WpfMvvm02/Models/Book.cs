using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace WpfMvvm02.Models
{
    public partial class Book:ObservableObject
    {
        [ObservableProperty]
        private int bookIdx;
        [ObservableProperty]            
        private string author;

        [ObservableProperty]
        private string divCode;
        [ObservableProperty]
        private string bookName;
        [ObservableProperty]
        private DateTime releaseDt;

        [ObservableProperty]
        private string isbn;


        [ObservableProperty]
        private Decimal price;

        

    }
}

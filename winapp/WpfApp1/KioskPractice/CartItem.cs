using System.ComponentModel;

namespace KioskPractice
{
    public class CartItem : INotifyPropertyChanged
    {
        public Product Product { get; set; }

        private int _quantity;
        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
                OnPropertyChanged(nameof(SubTotal));
            }
        }

        public int SubTotal => Product.Price * Quantity;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
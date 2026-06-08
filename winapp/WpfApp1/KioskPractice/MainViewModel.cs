using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace KioskPractice
{

    public class MainViewModel : INotifyPropertyChanged
    {
        public ICommand DecreaseQuantityCommand { get; }
        public ICommand IncreaseQuantityCommand { get; }
        // 1. 데이터 컬렉션 (ObservableCollection은 항목이 추가/삭제될 때 UI가 알아서 갱신됨)
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<CartItem> Cart { get; set; }

        // 2. 총 결제 금액 속성
        private int _totalPrice;
        public int TotalPrice
        {
            get => _totalPrice;
            set
            {
                _totalPrice = value;
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        // 3. 버튼과 연결될 명령(Command)
        public ICommand AddToCartCommand { get; }

        public MainViewModel()
        {
            // 1. DB 관리 직원(Service) 부르기
            var dbService = new DatabaseService();

            // 2. DB 세팅하기 (파일이 없으면 만들고 기초 데이터 삽입)
            dbService.InitializeDatabase();

            // 3. DB에서 리스트 가져오기
            var dbProducts = dbService.GetProducts();

            // 4. 화면(View)과 연결된 Products 컬렉션에 DB 데이터 집어넣기
            Products = new ObservableCollection<Product>(dbProducts);

            Cart = new ObservableCollection<CartItem>();
            AddToCartCommand = new RelayCommand(ExecuteAddToCart);

            DecreaseQuantityCommand = new RelayCommand(ExecuteDecreaseQuantity);
            IncreaseQuantityCommand = new RelayCommand(ExecuteIncreaseQuantity);
        }

        private void ExecuteAddToCart(object parameter)
        {
            if (parameter is Product selectedProduct)
            {
                // 이미 장바구니에 있는지 확인
                var existingItem = Cart.FirstOrDefault(item => item.Product.Name == selectedProduct.Name);

                if (existingItem != null)
                {
                    existingItem.Quantity++;
                }
                else
                {
                    Cart.Add(new CartItem { Product = selectedProduct, Quantity = 1 });
                }

                UpdateTotalPrice();
            }
        }

        private void UpdateTotalPrice()
        {
            TotalPrice = Cart.Sum(item => item.SubTotal);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private void ExecuteDecreaseQuantity(object parameter)
        {
            // 클릭한 줄의 장바구니 데이터(CartItem)를 받아옵니다.
            if (parameter is CartItem item)
            {
                item.Quantity--; // 수량 1 감소

                // 수량이 0이 되면 장바구니 목록에서 아예 제거합니다.
                if (item.Quantity <= 0)
                {
                    Cart.Remove(item);
                }

                UpdateTotalPrice(); // 총 금액 다시 계산
            }
        }

        // 4. 수량 증가 로직 (새로 추가)
        private void ExecuteIncreaseQuantity(object parameter)
        {
            if (parameter is CartItem item)
            {
                item.Quantity++; // 수량 1 증가
                UpdateTotalPrice();
            }
        }
    }
}
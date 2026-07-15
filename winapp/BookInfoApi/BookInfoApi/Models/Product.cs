namespace BookInfoApi.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        // string 뒤에 ? 를 붙여서 "비어있을 수도 있다(Nullable)"고 알려주면 경고가 사라집니다.
        public string? ProductName { get; set; }
        public string? Category { get; set; }

        public int Price { get; set; }
        public int Stock { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
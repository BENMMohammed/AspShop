namespace AspShop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Adresse { get; set; }
        public CartItem? CartItem { get; set; }
        public int? CartItemId { get; set; }
        public int NumOrder { get; set; }
        public int Product { get; set; }
        public int Quantity { get; set; }
        public int User { get; set; }
        public DateTime DateTime { get; set; }
        public ICollection<CartLineOrder>? CartLineOrder { get; set; }
    }
}

namespace AspShop.Models
{
    public class CartLineOrder
    {
        public int CartLineOrderId { get; set; }
        public int Quantity { get; set; }
        public int? UserId { get; set; }
        public int? OrderId { get; set; }
        public float Total { get; set; }
        public int UserX { get; set; }
        public int OrderX { get; set; }
        public User? User { get; set; }
        public Order? Order { get; set; }
    }
}

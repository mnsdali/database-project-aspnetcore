namespace OrdersAPI
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string? CustomerName { get; set; }
        public int ProductId { get; set; }
    }
}

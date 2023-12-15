namespace ProductsAPI
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = String.Empty;
        public int StockQte {  get; set; }
        public double Price { get; set; }

    }
}

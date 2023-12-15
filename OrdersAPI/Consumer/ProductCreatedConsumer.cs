using MassTransit;
using OrdersAPI.Data;
using Shared.Models;

namespace OrdersAPI.Consumer
{
    public class ProductCreatedConsumer : IConsumer<ProductCreated>
    {

        private readonly OrdersAPIContext ordersAPIContext;

        public ProductCreatedConsumer(OrdersAPIContext _ordersAPIContext)
        {
            ordersAPIContext = _ordersAPIContext; 
        }
        public async Task Consume(ConsumeContext<ProductCreated> context)
        {
            var newProduct = new Product
            {
                // Id = context.Message.Id;
                Name = context.Message.Name

            };
            ordersAPIContext.Add(newProduct);
            await ordersAPIContext.SaveChangesAsync();
        }
    }
}

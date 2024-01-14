using MassTransit;
using Model;
namespace ProductService
{
    public class InventoryService
    {
        private readonly IBusControl _busControl;

        public InventoryService(IBusControl busControl)
        {
            _busControl = busControl;
        }

        public async Task AddProduct(ProductDto productDto)
        {
            // Logic to add the product to the inventory

            var productAddedEvent = new ProductAddedEvent
            {
                ProductId = Guid.NewGuid(),
                ProductName = productDto.ProductName
            };

            // Publish the event to RabbitMQ
            await _busControl.Publish(productAddedEvent);
        }
    }
}

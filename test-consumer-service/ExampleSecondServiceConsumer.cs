using MassTransit;
using Model;

namespace ProductService
{
    public class ExampleSecondServiceConsumer : IConsumer<ProductAddedEvent>
    {
        public async Task Consume(ConsumeContext<ProductAddedEvent> context)
        {
            // Logic to send a notification for the added product
            var product = context.Message;
            await Console.Out.WriteLineAsync($"Notification 2: Product '{product.ProductName}' added. ProductId: {product.ProductId}");
            // Perform any necessary business logic for notifications
        }
    }

}

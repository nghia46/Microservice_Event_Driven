using MassTransit;
using Model;

namespace ProductService
{
    public class NotificationServiceConsumer : IConsumer<ProductAddedEvent>
    {
        public async Task Consume(ConsumeContext<ProductAddedEvent> context)
        {
            // Logic to send a notification for the added product
            var product = context.Message;
            await Console.Out.WriteLineAsync($"Notification: Product '{product.ProductName}' added. ProductId: {product.ProductId}");
            // Perform any necessary business logic for notifications
        }
    }

}

namespace Model
{
    public class ProductAddedEvent
    {
        public Guid ProductId { get; set; }
        public string? ProductName { get; set; }
    }

}

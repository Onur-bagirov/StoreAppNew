namespace StoreApp.Application.CQRS.Product.Command.Respones
{
    public class UpdateProductCommandResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
    }
}
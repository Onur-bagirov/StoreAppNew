namespace StoreApp.Application.CQRS.Product.Query.Respones
{
    class GetByIdProductQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
    }
}

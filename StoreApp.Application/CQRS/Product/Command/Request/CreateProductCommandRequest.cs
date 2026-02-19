using MediatR;
using StoreApp.Application.CQRS.Product.Command.Respones;
using StoreApp.Comman.GlobalResponse.Generics.ResponseModel;

namespace StoreApp.Application.CQRS.Product.Command.Request
{
    public class CreateProductCommandRequest : IRequest<ResponseModel<CreateProductCommandResponse>>
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
    }
}
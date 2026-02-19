using MediatR;
using StoreApp.Application.CQRS.Categories.Command.Response;
using StoreApp.Application.CQRS.Product.Command.Respones;
using StoreApp.Comman.GlobalResponse.Generics.ResponseModel;

namespace StoreApp.Application.CQRS.Product.Command.Request
{
    public class UpdateProductCommandRequest : IRequest<ResponseModel<UpdateProductCommandResponse>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
    }
}
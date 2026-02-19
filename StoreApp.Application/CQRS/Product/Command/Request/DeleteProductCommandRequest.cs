using MediatR;
using StoreApp.Application.CQRS.Categories.Command.Response;
using StoreApp.Application.CQRS.Product.Command.Respones;
using StoreApp.Comman.GlobalResponse.Generics.ResponseModel;

namespace StoreApp.Application.CQRS.Product.Command.Request
{
    public class DeleteProductCommandRequest : IRequest<ResponseModel<DeleteProductCommandResponse>>
    {
        public int Id { get; set; }
    }
}
using MediatR;
using StoreApp.Application.CQRS.Categories.Command.Response;
using StoreApp.Comman.GlobalResponse.Generics.ResponseModel;
namespace StoreApp.Application.CQRS.Categories.Command.Request
{
    public class DeleteCategoryCommandRequest : IRequest<ResponseModel<DeleteCategoryCommandResponse>>
    {
        public int Id { get; set; }
    }
}
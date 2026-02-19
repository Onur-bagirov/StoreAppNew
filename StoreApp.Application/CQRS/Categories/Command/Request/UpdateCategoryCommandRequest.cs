using MediatR;
using StoreApp.Application.CQRS.Categories.Command.Response;
using StoreApp.Comman.GlobalResponse.Generics.ResponseModel;
namespace StoreApp.Application.CQRS.Categories.Command.Request
{
    public class UpdateCategoryCommandRequest : IRequest<ResponseModel<UpdateCategoryCommandResponse>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

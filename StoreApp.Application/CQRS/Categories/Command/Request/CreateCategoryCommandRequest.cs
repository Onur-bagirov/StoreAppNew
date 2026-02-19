using MediatR;
using StoreApp.Application.CQRS.Categories.Command.Response;
using StoreApp.Comman.GlobalResponse.Generics.ResponseModel;

namespace StoreApp.Application.CQRS.Categories.Command.Request;

public class CreateCategoryCommandRequest:IRequest<ResponseModel<CreateCategoryCommandResponse>>
{
    public string Name { get; set; }
}

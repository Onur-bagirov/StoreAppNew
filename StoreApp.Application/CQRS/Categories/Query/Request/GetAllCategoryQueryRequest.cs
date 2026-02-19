using MediatR;
using StoreApp.Application.CQRS.Categories.Query.Response;
using StoreApp.Comman.GlobalResponse.Generics.ResponseModel;
namespace StoreApp.Application.CQRS.Categories.Query.Request;
public class GetAllCategoryQueryRequest:IRequest<Pagination<GetAllCategoryQueryResponse>>
{
    public int Limit { get; set; } = 15;
    public int Page { get; set; } = 1;
}
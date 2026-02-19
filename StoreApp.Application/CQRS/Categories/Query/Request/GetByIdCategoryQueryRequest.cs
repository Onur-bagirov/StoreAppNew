using MediatR;
using StoreApp.Application.CQRS.Categories.Query.Response;
using StoreApp.Comman.GlobalResponse.Generics.ResponseModel;
namespace StoreApp.Application.CQRS.Categories.Query.Request
{
    public class GetByIdCategoryQueryRequest : IRequest<ResponseModel<GetByIdCategoryQueryResponse>>
    {
        public int Id { get; set; }
    }
}
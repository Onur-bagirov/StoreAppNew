using MediatR;
using StoreApp.Application.CQRS.Categories.Query.Response;
using StoreApp.Application.CQRS.Product.Query.Respones;
using StoreApp.Comman.GlobalResponse.Generics.ResponseModel;
namespace StoreApp.Application.CQRS.Product.Query.Request
{
    public class GetAllProductQueryRequest : IRequest<Pagination<GetAllProductQueryResponse>>
    {
        public int Limit { get; set; } = 15;
        public int Page { get; set; } = 1;
    }
}
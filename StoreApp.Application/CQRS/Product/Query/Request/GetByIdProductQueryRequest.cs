using MediatR;
using StoreApp.Application.CQRS.Product.Query.Respones;
using StoreApp.Comman.GlobalResponse.Generics.ResponseModel;

namespace StoreApp.Application.CQRS.Product.Query.Request
{
    public class GetByIdProductQueryRequest : IRequest<ResponseModel<GetByIdProductQueryResponse>>
    {
        public int Id {  get; set; }
    }
}

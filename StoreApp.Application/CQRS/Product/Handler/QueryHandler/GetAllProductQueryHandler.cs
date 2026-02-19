using MediatR;
using StoreApp.Application.CQRS.Product.Query.Request;
using StoreApp.Application.CQRS.Product.Query.Respones;
using StoreApp.Comman.GlobalResponse.Generics.ResponseModel;
using StoreApp.Repository.Comman;

namespace StoreApp.Application.CQRS.Product.Handler.QueryHandler
{
    class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest,Pagination<GetAllProductQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllProductQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork; 
        }

        public async Task<Pagination<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request,CancellationToken cancellationToken)
        {
            var products = _unitOfWork.ProductRepository.GetAll();
            var totalCount = products.Count();
            var paginatedProducts = products.Skip((request.Page - 1) * request.Limit).Take(request.Limit).ToList();

            var response = paginatedProducts.Select(x => new GetAllProductQueryResponse()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                CategoryId = x.CategoryId,
            }).ToList();

            return new Pagination<GetAllProductQueryResponse>(response, totalCount, request.Page, request.Limit);
        }
    }
}
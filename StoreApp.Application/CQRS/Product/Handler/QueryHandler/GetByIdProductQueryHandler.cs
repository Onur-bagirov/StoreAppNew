using StoreApp.Application.CQRS.Categories.Query.Request;
using StoreApp.Application.CQRS.Categories.Query.Response;
using StoreApp.Application.CQRS.Product.Query.Request;
using StoreApp.Application.CQRS.Product.Query.Respones;
using StoreApp.Comman.GlobalResponse.Generics.ResponseModel;
using StoreApp.Repository.Comman;

namespace StoreApp.Application.CQRS.Product.Handler.QueryHandler
{
    class GetByIdProductQueryHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetByIdProductQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork; 
        }

        public async Task<ResponseModel<GetByIdProductQueryResponse>> Handle(GetByIdProductQueryRequest request,CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.Id);

            if(product != null)
            {
                var byId = new GetByIdProductQueryResponse
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    CategoryId = product.CategoryId,
                };

                return new ResponseModel<GetByIdProductQueryResponse>(byId);
            }

            return new ResponseModel<GetByIdProductQueryResponse>(null);
        }
    }
}

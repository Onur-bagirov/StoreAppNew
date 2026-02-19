using MediatR;
using StoreApp.Application.CQRS.Categories.Query.Request;
using StoreApp.Application.CQRS.Categories.Query.Response;
using StoreApp.Comman.GlobalResponse.Generics.ResponseModel;
using StoreApp.Repository.Comman;

namespace StoreApp.Application.CQRS.Categories.Handler.QueryHandler
{
    class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQueryRequest ,ResponseModel<GetByIdCategoryQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetByIdCategoryQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork; 
        }

        public async Task<ResponseModel<GetByIdCategoryQueryResponse>> Handle(GetByIdCategoryQueryRequest request,CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request.Id);

            if(category != null)
            {
                var ById = new GetByIdCategoryQueryResponse
                {
                    Id = category.Id,
                    Name = category.Name,
                };

                return new ResponseModel<GetByIdCategoryQueryResponse>(ById);
            }

            return new ResponseModel<GetByIdCategoryQueryResponse>(null);
        }
    }
}
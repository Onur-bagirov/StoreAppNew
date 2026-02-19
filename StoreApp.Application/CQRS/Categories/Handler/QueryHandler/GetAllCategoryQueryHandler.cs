using MediatR;
using StoreApp.Application.CQRS.Categories.Query.Request;
using StoreApp.Application.CQRS.Categories.Query.Response;
using StoreApp.Comman.GlobalResponse.Generics.ResponseModel;
using StoreApp.Repository.Comman;

namespace StoreApp.Application.CQRS.Categories.Handler.QueryHandler;

class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, Pagination<GetAllCategoryQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllCategoryQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Pagination<GetAllCategoryQueryResponse>> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
    {
        var categories = _unitOfWork.CategoryRepository.GetAll();
        var totalCount = categories.Count();
        var paginatedCategories = categories.Skip((request.Page - 1) * request.Limit).Take(request.Limit).ToList();
        var response = paginatedCategories.Select(c => new GetAllCategoryQueryResponse
        {
            Id = c.Id,
            Name = c.Name
        }).ToList();
        return new Pagination<GetAllCategoryQueryResponse>(response, totalCount, request.Page, request.Limit);
    }
}

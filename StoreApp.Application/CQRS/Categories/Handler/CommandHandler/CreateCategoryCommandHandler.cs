using MediatR;
using StoreApp.Application.CQRS.Categories.Command.Request;
using StoreApp.Application.CQRS.Categories.Command.Response;
using StoreApp.Comman.GlobalResponse.Generics.ResponseModel;
using StoreApp.Domain.Entities;
using StoreApp.Repository.Comman;

namespace StoreApp.Application.CQRS.Categories.Handler.CommandHandler;

class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, ResponseModel<CreateCategoryCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<CreateCategoryCommandResponse>> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var category = new Category
        {
            Name = request.Name
        };
        await _unitOfWork.CategoryRepository.AddAsync(category);
        await _unitOfWork.SaveChangesAsync();
        var response = new CreateCategoryCommandResponse
        {
            Id = category.Id,
            Name = category.Name
        };
        return new ResponseModel<CreateCategoryCommandResponse>(response);

    }
}
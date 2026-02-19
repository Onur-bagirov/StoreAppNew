using MediatR;
using StoreApp.Application.CQRS.Product.Command.Request;
using StoreApp.Application.CQRS.Product.Command.Respones;
using StoreApp.Comman.GlobalResponse.Generics.ResponseModel;
using StoreApp.Domain.Entities;
using StoreApp.Repository.Comman;
namespace StoreApp.Application.CQRS.Product.Handler.CommandHandler
{
    class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest,ResponseModel<CreateProductCommandResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseModel<CreateProductCommandResponse>> Handle(CreateProductCommandRequest request,CancellationToken cancellationToken)
        {
            var product = new Domain.Entities.Product
            {
                Name = request.Name,
                Price = request.Price,
                CategoryId = request.CategoryId
            };

            await _unitOfWork.ProductRepository.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();

            var response = new CreateProductCommandResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.CategoryId
            };

            return new ResponseModel<CreateProductCommandResponse>(response);
        }
    }
}
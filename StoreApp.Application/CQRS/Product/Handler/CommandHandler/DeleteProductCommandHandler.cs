using MediatR;
using StoreApp.Application.CQRS.Categories.Command.Request;
using StoreApp.Application.CQRS.Categories.Command.Response;
using StoreApp.Application.CQRS.Product.Command.Request;
using StoreApp.Application.CQRS.Product.Command.Respones;
using StoreApp.Comman.GlobalResponse.Generics.ResponseModel;
using StoreApp.Repository.Comman;

namespace StoreApp.Application.CQRS.Product.Handler.CommandHandler
{
    class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest,ResponseModel<DeleteProductCommandResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork; 
        }

        public async Task <ResponseModel<DeleteProductCommandResponse>> Handle(DeleteProductCommandRequest request,CancellationToken cancellation)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.Id);

            if (product != null)
            {
                _unitOfWork.ProductRepository.Delete(request.Id);
                await _unitOfWork.SaveChangesAsync();

                var response = new DeleteProductCommandResponse
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    CategoryId = product.CategoryId,
                };

                return new ResponseModel<DeleteProductCommandResponse>(response);
            }

            return new ResponseModel<DeleteProductCommandResponse>(null);
        }
    }
}
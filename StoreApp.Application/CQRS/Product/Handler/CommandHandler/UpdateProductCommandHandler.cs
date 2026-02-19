using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using StoreApp.Application.CQRS.Categories.Command.Request;
using StoreApp.Application.CQRS.Categories.Command.Response;
using StoreApp.Application.CQRS.Categories.Handler.CommandHandler;
using StoreApp.Application.CQRS.Product.Command.Request;
using StoreApp.Application.CQRS.Product.Command.Respones;
using StoreApp.Comman.GlobalResponse.Generics.ResponseModel;
using StoreApp.Repository.Comman;

namespace StoreApp.Application.CQRS.Product.Handler.CommandHandler
{
    class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, ResponseModel<UpdateProductCommandResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseModel<UpdateProductCommandResponse>> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.Id);

            if (product != null)
            {
                product.Name = request.Name;
                _unitOfWork.ProductRepository.Update(product);
                await _unitOfWork.SaveChangesAsync();

                var updateProduct = new UpdateProductCommandResponse
                {
                    Id = request.Id,
                    Name = request.Name,
                    Price = request.Price,
                    CategoryId = request.CategoryId,
                };

                return new ResponseModel<UpdateProductCommandResponse>(updateProduct);
            }

            return new ResponseModel<UpdateProductCommandResponse>(null);
        }
    }
}

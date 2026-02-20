using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using StoreApp.Application.CQRS.Categories.Command.Request;
using StoreApp.Application.CQRS.Categories.Command.Response;
using StoreApp.Comman.GlobalResponse.Generics.ResponseModel;
using StoreApp.Repository.Comman;

namespace StoreApp.Application.CQRS.Categories.Handler.CommandHandler
{
    class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest,ResponseModel<DeleteCategoryCommandResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork; 
        }

        public async Task<ResponseModel<DeleteCategoryCommandResponse>> Handle(DeleteCategoryCommandRequest request,CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request.Id);
            var products = _unitOfWork.ProductRepository.GetAll().Where(p => p.CategoryId == request.Id && !p.IsDeleted).ToList();


            if (category != null)
            {
                _unitOfWork.CategoryRepository.Delete(request.Id);
                await _unitOfWork.SaveChangesAsync();

                foreach (var product in products)
                {
                    product.IsDeleted = true;
                    _unitOfWork.ProductRepository.Update(product);
                }

                await _unitOfWork.SaveChangesAsync();

                var response = new DeleteCategoryCommandResponse
                {
                    Id = category.Id,
                    Name = category.Name
                };


                return new ResponseModel<DeleteCategoryCommandResponse>(response);
            }

            return new ResponseModel<DeleteCategoryCommandResponse>(null);
        }
    }
}
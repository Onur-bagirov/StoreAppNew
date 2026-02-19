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
    class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest,ResponseModel<UpdateCategoryCommandResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork; 
        }

        public async Task<ResponseModel<UpdateCategoryCommandResponse>> Handle(UpdateCategoryCommandRequest request,CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request.Id);

            if(category != null)
            {
                category.Name = request.Name;
                _unitOfWork.CategoryRepository.Update(category);
                await _unitOfWork.SaveChangesAsync();

                var updateCategory = new UpdateCategoryCommandResponse
                {
                    Id = category.Id,
                    Name = category.Name,
                };

                return new ResponseModel<UpdateCategoryCommandResponse>(updateCategory);
            }

            return new ResponseModel<UpdateCategoryCommandResponse>(null);
        }
    }
}
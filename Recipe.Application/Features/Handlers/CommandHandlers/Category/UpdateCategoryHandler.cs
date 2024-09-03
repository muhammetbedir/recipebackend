using AutoMapper;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using Recipe.Application.Common.Helpers;
using Recipe.Application.Dtos.Common;
using Recipe.Application.Features.Commands.Category;
using Recipe.Application.Repository;
using Recipe.Domain.Models;

namespace Recipe.Application.Features.Handlers.CommandHandlers.Category
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IGenericRepository<CategoryEntity> _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateCategoryHandler(IGenericRepository<CategoryEntity> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CategoryEntity>(request);
            if (!request.ImageData.IsNullOrEmpty() && request.ImageData.Length > 0)
            {
                entity.ImageUrl = await FileService.SaveImageAsync(request.ImageData, $"recipe_{entity.Id}.jpg");
            }
            await _categoryRepository.UpdateAsync(entity);
            await _categoryRepository.CommitAsync();
        }
    }
}

using AutoMapper;
using MediatR;
using Recipe.Application.Common.Helpers;
using Recipe.Application.Dtos.Common;
using Recipe.Application.Features.Commands.Category;
using Recipe.Application.Repository;
using Recipe.Domain.Models;

namespace Recipe.Application.Features.Handlers.CommandHandlers.Category
{
    public class AddCategoryHandler : IRequestHandler<AddCategoryCommand, AddResponseDto>
    {
        private readonly IGenericRepository<CategoryEntity> _categoryRepository;
        private readonly IMapper _mapper;

        public AddCategoryHandler(IGenericRepository<CategoryEntity> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<AddResponseDto> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CategoryEntity>(request);
            if (request.ImageData.Length > 0)
            {
                entity.ImageUrl = await FileService.SaveImageAsync(request.ImageData, $"category_{entity.Id}.jpg");
            }
            await _categoryRepository.InsertAsync(entity);
            await _categoryRepository.CommitAsync();
            var response = _mapper.Map<AddResponseDto>(entity);
            return response;
        }
    }
}

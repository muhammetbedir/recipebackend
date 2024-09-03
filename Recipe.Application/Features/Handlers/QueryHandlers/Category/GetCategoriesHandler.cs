using AutoMapper;
using MediatR;
using Recipe.Application.Features.Queries.Category;
using Recipe.Application.Repository;
using Recipe.Domain.Models;
using Recipe.Presentation.Dtos.Category;

namespace Recipe.Application.Features.Handlers.QueryHandlers.Category
{
    public class GetCategoriesHandler : IRequestHandler<GetCategoriesQuery, List<CategoryDto>>
    {
        private readonly IGenericRepository<CategoryEntity> _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoriesHandler(IGenericRepository<CategoryEntity> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllAsync();
            var categoryDtos = _mapper.Map<List<CategoryDto>>(categories);
            return categoryDtos;
        }
    }
}

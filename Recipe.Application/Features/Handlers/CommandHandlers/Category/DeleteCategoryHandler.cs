using AutoMapper;
using MediatR;
using Recipe.Application.Features.Commands.Category;
using Recipe.Application.Repository;
using Recipe.Domain.Models;

namespace Recipe.Application.Features.Handlers.CommandHandlers.Category
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IGenericRepository<CategoryEntity> _categoryRepository;
        private readonly IMapper _mapper;

        public DeleteCategoryHandler(IGenericRepository<CategoryEntity> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            await _categoryRepository.deleteByIdAsync(request.Id);
            await _categoryRepository.CommitAsync();
        }
    }
}

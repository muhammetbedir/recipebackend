using AutoMapper;
using MediatR;
using Nest;
using Recipe.Application.Common.Helpers;
using Recipe.Application.Features.Commands.Recipe;
using Recipe.Application.Repository;
using Recipe.Domain.Models;
using Recipe.Presentation.Dtos.Recipe;

namespace Recipe.Application.Features.Handlers.CommandHandlers.Recipe
{
    public class AddRecipeHandler : IRequestHandler<AddRecipeCommand, AddRecipeDto>
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;
        private readonly IElasticClient _elasticClient;
        public AddRecipeHandler(IRecipeRepository recipeRepository, IMapper mapper, IElasticClient elasticClient)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
            _elasticClient = elasticClient;
        }

        public async Task<AddRecipeDto> Handle(AddRecipeCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<RecipeEntity>(request);
            await _recipeRepository.InsertAsync(entity);
            if (request.ImageData.Length > 0)
            {
                entity.ImageUrl = await FileService.SaveImageAsync(request.ImageData, $"recipe_{entity.Id}.jpg");
            }
            await _recipeRepository.CommitAsync();
            var response = _mapper.Map<AddRecipeDto>(entity);


            var dbData = await _recipeRepository.GetByIdAsync(entity.Id);
            await _elasticClient.IndexDocumentAsync(dbData);

            return response;
        }
    }
}

using AutoMapper;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using Nest;
using Recipe.Application.Common.Helpers;
using Recipe.Application.Features.Commands.Recipe;
using Recipe.Application.Repository;
using Recipe.Domain.Models;

namespace Recipe.Application.Features.Handlers.CommandHandlers.Recipe
{
    public class UpdateRecipeHandler : IRequestHandler<UpdateRecipeCommand>
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;
        private readonly IElasticClient _elasticClient;

        public UpdateRecipeHandler(IRecipeRepository recipeRepository, IMapper mapper, IElasticClient elasticClient)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
            _elasticClient = elasticClient;
        }

        public async Task Handle(UpdateRecipeCommand request, CancellationToken cancellationToken)
        {
            // Var olan entity'yi veritabanından al
            var existingEntity = await _recipeRepository.GetByIdAsync(request.Id.Value);

            if (existingEntity == null)
            {
                // Hata veya entity'nin bulunamadığı durumu ele al
                throw new KeyNotFoundException($"Recipe with Id {request.Id} not found.");
            }

            // Mapper ile güncellemeleri mevcut entity'ye uygula
            _mapper.Map(request, existingEntity);

            if (!request.ImageData.IsNullOrEmpty() && request.ImageData.Length > 0)
            {
                await FileService.DeleteImageAsync($"recipe_{existingEntity.Id}.jpg");
                existingEntity.ImageUrl = await FileService.SaveImageAsync(request.ImageData, $"recipe_{existingEntity.Id}.jpg");
            }

            // Güncellenmiş entity'yi veritabanında güncelle
            _recipeRepository.Update(existingEntity);
            await _recipeRepository.CommitAsync();

            // Elasticsearch'e güncellenmiş entity'yi indeksle
            await _elasticClient.IndexDocumentAsync(existingEntity);
        }


    }
}

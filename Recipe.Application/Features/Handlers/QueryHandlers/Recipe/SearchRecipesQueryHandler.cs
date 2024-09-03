using AutoMapper;
using MediatR;
using Nest;
using Recipe.Application.Features.Queries.Recipe;
using Recipe.Application.Repository;
using Recipe.Domain.Models;
using Recipe.Presentation.Dtos.Recipe;

public class SearchRecipesQueryHandler : IRequestHandler<SearchRecipesQuery, List<GetAllRecipesDto>>
{
    private readonly IElasticClient _elasticClient;
    private readonly IMapper _mapper;
    private readonly IRecipeRepository _recipeRepository;
    public SearchRecipesQueryHandler(IElasticClient elasticClient, IMapper mapper, IRecipeRepository recipeRepository)
    {
        _elasticClient = elasticClient;
        _mapper = mapper;
        _recipeRepository = recipeRepository;

        if (!elasticClient.Indices.Exists("recipes").Exists)
        {
            elasticClient.Indices.Create("recipes",
                index => index.Map<RecipeEntity>(
                    x => x.AutoMap()
                )
            );

            var recipes = _recipeRepository.GetAll();
            if (recipes.Any())
            {
                elasticClient.Bulk(b => b
                    .Index("recipes")
                    .IndexMany(recipes)
                );
            }
        }
    }

    public async Task<List<GetAllRecipesDto>> Handle(SearchRecipesQuery request, CancellationToken cancellationToken)
    {
        var response = await _elasticClient.SearchAsync<RecipeEntity>(s => s
            .Index("recipes") 
            .Query(q => q
                .MultiMatch(m => m
                    .Query(request.Query)
                    .Fields(f => f
                        .Field(r => r.Title)
                        .Field(r => r.Description)
                        .Field(r => r.Ingredients)
                        .Field(r => r.CategoryId)
                    )
                )
            ), cancellationToken);

        if (!response.IsValid)
        {
            throw new Exception("Failed to search documents: " + response.OriginalException.Message);
        }

        var responseDto = _mapper.Map<List<GetAllRecipesDto>>(response.Documents.ToList());

        return responseDto;
    }

}

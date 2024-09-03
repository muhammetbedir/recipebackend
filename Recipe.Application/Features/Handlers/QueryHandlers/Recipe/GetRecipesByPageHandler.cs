using AutoMapper;
using MediatR;
using Recipe.Application.Features.Queries.Recipe;
using Recipe.Application.Repository;
using Recipe.Presentation.Dtos.Recipe;

namespace Recipe.Application.Features.Handlers.QueryHandlers.Recipe
{
    public class GetRecipesByPageHandler : IRequestHandler<GetRecipesByPageQuery, List<GetAllRecipesDto>>
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;

        public GetRecipesByPageHandler(IRecipeRepository recipeRepository, IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllRecipesDto>> Handle(GetRecipesByPageQuery request, CancellationToken cancellationToken)
        {
            var data = await _recipeRepository.getRecipesByPage(request);
            var dataDto = _mapper.Map<List<GetAllRecipesDto>>(data);
            if (request.UserId == null) return dataDto;
            foreach (var item in data)
            {
                if (item.Books.Any(x => x.UserId == request.UserId))
                {
                    var recipe = dataDto.Where(x => x.Id == item.Id).FirstOrDefault();
                    recipe.IsBooked = true;
                }
            }
            return dataDto;
        }
    }
}

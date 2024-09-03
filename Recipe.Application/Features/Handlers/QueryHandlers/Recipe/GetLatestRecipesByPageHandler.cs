using AutoMapper;
using MediatR;
using Recipe.Application.Features.Queries.Recipe;
using Recipe.Application.Interfaces.Repository;
using Recipe.Application.Repository;
using Recipe.Presentation.Dtos.Recipe;

namespace Recipe.Application.Features.Handlers.QueryHandlers.Recipe
{
    public class GetLatestRecipesByPageHandler : IRequestHandler<GetLatestRecipesByPageQuery, List<GetAllRecipesDto>>
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public GetLatestRecipesByPageHandler(IRecipeRepository recipeRepository, IMapper mapper, ICommentRepository commentRepository)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
            _commentRepository = commentRepository;
        }
        public async Task<List<GetAllRecipesDto>> Handle(GetLatestRecipesByPageQuery request, CancellationToken cancellationToken)
        {
            var latestRecipes = await _recipeRepository.getLatestRecipesByPage(request);
            var responseDto = _mapper.Map<List<GetAllRecipesDto>>(latestRecipes);
            foreach (var item in latestRecipes)
            {
                var recipe = responseDto.Where(x => x.Id == item.Id).FirstOrDefault();
                if (item.Books.Any(x => x.UserId == request.UserId))
                {
                    recipe.IsBooked = true;
                    recipe.BookId = item.Books.FirstOrDefault(x => x.UserId == request.UserId)?.Id;
                }
                recipe.CommentCount = await _commentRepository.getCommentCountByRecipeId(item.Id);
            }
            return responseDto;
        }
    }
}

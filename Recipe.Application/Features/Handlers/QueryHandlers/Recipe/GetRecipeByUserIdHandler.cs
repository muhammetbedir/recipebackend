using AutoMapper;
using MediatR;
using Recipe.Application.Features.Queries.Recipe;
using Recipe.Application.Interfaces.Repository;
using Recipe.Application.Repository;
using Recipe.Presentation.Dtos.Recipe;

namespace Recipe.Application.Features.Handlers.QueryHandlers.Recipe
{
    public class GetRecipeByUserIdHandler : IRequestHandler<GetRecipeByUserIdQuery, List<GetAllRecipesDto>>
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public GetRecipeByUserIdHandler(IRecipeRepository recipeRepository, IMapper mapper, ICommentRepository commentRepository)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
            _commentRepository = commentRepository;
        }
        public async Task<List<GetAllRecipesDto>> Handle(GetRecipeByUserIdQuery request, CancellationToken cancellationToken)
        {
            var userRecipes = await _recipeRepository.getRecipesByUserId(request.ProfileId);
            var responseDto = _mapper.Map<List<GetAllRecipesDto>>(userRecipes);
            foreach (var item in userRecipes)
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

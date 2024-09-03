using AutoMapper;
using MediatR;
using Recipe.Application.Features.Queries.Recipe;
using Recipe.Application.Interfaces.Repository;
using Recipe.Application.Repository;
using Recipe.Presentation.Dtos.Recipe;

namespace Recipe.Application.Features.Handlers.QueryHandlers.Recipe
{
    public class GetRecipesByCategoryNameAndPageHandler : IRequestHandler<GetRecipesByCategoryAndPageQuery, List<GetAllRecipesDto>>
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;
        private readonly ICommentRepository _commentRepository;
        public GetRecipesByCategoryNameAndPageHandler(IRecipeRepository recipeRepository, IMapper mapper, ICommentRepository commentRepository)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
            _commentRepository = commentRepository;
        }

        public async Task<List<GetAllRecipesDto>> Handle(GetRecipesByCategoryAndPageQuery request, CancellationToken cancellationToken)
        {
            var data = await _recipeRepository.getRecipesByCategoryAndPage(request);
            var dataDto = _mapper.Map<List<GetAllRecipesDto>>(data);
            foreach (var item in data)
            {
                var recipe = dataDto.Where(x => x.Id == item.Id).FirstOrDefault();
                if (item.Books.Any(x => x.UserId == request.UserId))
                {
                    recipe.IsBooked = true;
                    recipe.BookId = item.Books.FirstOrDefault(x => x.UserId == request.UserId)?.Id;
                }
                recipe.CommentCount = await _commentRepository.getCommentCountByRecipeId(item.Id);
            }
            return dataDto;
        }
    }
}

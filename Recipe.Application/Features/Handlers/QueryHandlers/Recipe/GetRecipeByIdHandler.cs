using AutoMapper;
using MediatR;
using Recipe.Application.Dtos.Recipe;
using Recipe.Application.Features.Queries.Recipe;
using Recipe.Application.Repository;
using Recipe.Presentation.Dtos.Recipe;

namespace Recipe.Application.Features.Handlers.QueryHandlers.Recipe
{
    public class GetRecipeByIdHandler : IRequestHandler<GetRecipesByIdQuery, GetRecipeByIdDto>
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;

        public GetRecipeByIdHandler(IRecipeRepository recipeRepository, IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }
        public async Task<GetRecipeByIdDto> Handle(GetRecipesByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _recipeRepository.getRecipesById(request.Id);
            var dataDto = _mapper.Map<GetRecipeByIdDto>(data);
            if(data != null)
            {
                dataDto.IsBooked = data.Books.Where(x => x.UserId == request.UserId).Any();
                dataDto.BookId = data.Books.FirstOrDefault(x => x.UserId == request.UserId)?.Id;
            }
            return dataDto;
        }
    }
}

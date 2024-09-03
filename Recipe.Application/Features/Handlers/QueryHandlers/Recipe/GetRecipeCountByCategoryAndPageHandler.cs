using AutoMapper;
using MediatR;
using Recipe.Application.Features.Queries.Recipe;
using Recipe.Application.Repository;
using Recipe.Presentation.Dtos.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.Features.Handlers.QueryHandlers.Recipe
{
    public class GetRecipeCountByCategoryAndPageHandler : IRequestHandler<GetRecipeCountByCategoryAndPageQuery,int>
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;

        public GetRecipeCountByCategoryAndPageHandler(IRecipeRepository recipeRepository, IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(GetRecipeCountByCategoryAndPageQuery request, CancellationToken cancellationToken)
        {
            return await _recipeRepository.getRecipeCountByCategoryAndPage(request);
        }
    }
}

using AutoMapper;
using MediatR;
using Recipe.Application.Features.Queries.Recipe;
using Recipe.Application.Interfaces.Repository;
using Recipe.Application.Repository;
using Recipe.Presentation.Dtos.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.Features.Handlers.QueryHandlers.Recipe
{
    public class GetRecipeCountHandler : IRequestHandler<GetRecipeCountQuery, int>
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;

        public GetRecipeCountHandler(IRecipeRepository recipeRepository, IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(GetRecipeCountQuery request, CancellationToken cancellationToken)
        {
            return await _recipeRepository.getRecipeCount();
        }
    }
}

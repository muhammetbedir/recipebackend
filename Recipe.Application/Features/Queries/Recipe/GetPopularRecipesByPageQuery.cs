﻿using MediatR;
using Recipe.Presentation.Dtos.Common;
using Recipe.Presentation.Dtos.Recipe;

namespace Recipe.Application.Features.Queries.Recipe
{
    public class GetPopularRecipesByPageQuery : PaginationRequestDto, IRequest<List<GetAllRecipesDto>>
    {
        public Guid? UserId { get; set; }
    }
}

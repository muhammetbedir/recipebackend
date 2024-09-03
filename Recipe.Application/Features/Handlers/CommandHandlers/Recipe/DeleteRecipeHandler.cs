using AutoMapper;
using MediatR;
using Recipe.Application.Features.Commands.Recipe;
using Recipe.Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.Features.Handlers.CommandHandlers.Recipe
{
    public class DeleteRecipeHandler : IRequestHandler<DeleteRecipeCommand>
    {
        private readonly IRecipeRepository _recipeRepository;
        public DeleteRecipeHandler(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }
        public async Task Handle(DeleteRecipeCommand request, CancellationToken cancellationToken)
        {
            var data = await _recipeRepository.GetByIdAsync(request.Id);
            await _recipeRepository.deleteAsync(data);
            await _recipeRepository.CommitAsync();
        }
    }
}

using AutoMapper;
using MediatR;
using Recipe.Application.Common.Helpers;
using Recipe.Application.Features.Commands.Recipe;
using Recipe.Application.Interfaces.Repository;
using Recipe.Domain.Models;

namespace Recipe.Application.Features.Handlers.CommandHandlers.Recipe
{
    public class AddRecipeTutorialPicturesHandler : IRequestHandler<AddRecipeTutorialPicturesComand>
    {
        private readonly IRecipeTutorialPictureRepository _recipeTutorialPictureRepository;
        private readonly IMapper _mapper;
        public AddRecipeTutorialPicturesHandler(IMapper mapper, IRecipeTutorialPictureRepository recipeTutorialPictureRepository)
        {
            _mapper = mapper;
            _recipeTutorialPictureRepository = recipeTutorialPictureRepository;
        }

        public async Task Handle(AddRecipeTutorialPicturesComand request, CancellationToken cancellationToken)
        {
            var pictures = await _recipeTutorialPictureRepository.getAllRecipeTutorialPicturesByRecipeId(request.Pictures.FirstOrDefault().RecipeId);
            foreach (var pic in pictures)
            {
                await _recipeTutorialPictureRepository.deleteAsync(pic);
                await FileService.DeleteImageAsync( $"recipe_{pic.RecipeId}_{pic.Order}.jpg");
            }
            if (pictures.Any())
            {
                await _recipeTutorialPictureRepository.CommitAsync();
            }
            foreach (var item in request.Pictures)
            {
                var entity = _mapper.Map<RecipeTutorialPictureEntity>(item);
                if (item.ImageData.Length > 0)
                {
                    entity.ImageUrl = await FileService.SaveImageAsync(item.ImageData, $"recipe_{entity.RecipeId}_{entity.Order}.jpg");
                }
                await _recipeTutorialPictureRepository.InsertAsync(entity);
            }
            await _recipeTutorialPictureRepository.CommitAsync();
        }

    }
}

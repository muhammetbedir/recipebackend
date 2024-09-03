using MediatR;

namespace Recipe.Application.Features.Commands.Recipe
{
    public class UpdateRecipeCommand : IRequest
    {
        public Guid? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }
        public string Ingredients { get; set; }
        public byte[]? ImageData { get; set; }
        public string ImageUrl { get; set; }
        public int PreparationTime { get; set; }
        public int CookingTime { get; set; }
        public int Servings { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid UserId { get; set; }
    }
}

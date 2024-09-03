using MediatR;
using static Recipe.Common.Enums.StatusEnums;

namespace Recipe.Application.Features.Commands.Category
{
    public class UpdateCategoryCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public StatusEnum Status { get; set; }
        public byte[]? ImageData { get; set; }
        public string ImageUrl { get; set; }
    }
}

using MediatR;
using Recipe.Application.Dtos.Common;
using static Recipe.Common.Enums.StatusEnums;

namespace Recipe.Application.Features.Commands.Category
{
    public class AddCategoryCommand : IRequest<AddResponseDto>
    {
        public string Name { get; set; }
        public StatusEnum Status { get; set; }
        public byte[]? ImageData { get; set; }
    }
}

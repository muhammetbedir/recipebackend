using MediatR;
using Recipe.Presentation.Dtos.Category;

namespace Recipe.Application.Features.Queries.Category
{
    public class GetCategoriesQuery : IRequest<List<CategoryDto>>
    {
    }
}

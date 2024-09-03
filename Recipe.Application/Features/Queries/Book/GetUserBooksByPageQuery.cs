using MediatR;
using Recipe.Application.Dtos.Book;
using Recipe.Presentation.Dtos.Common;

namespace Recipe.Application.Features.Queries.Book
{
    public class GetUserBooksByPageQuery : PaginationRequestDto, IRequest<List<BookDto>>
    {
        public Guid? UserId { get; set; }
    }
}

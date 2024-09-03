using AutoMapper;
using MediatR;
using Recipe.Application.Dtos.Book;
using Recipe.Application.Features.Queries.Book;
using Recipe.Application.Interfaces.Repository;

namespace Recipe.Application.Features.Handlers.QueryHandlers.Book
{
    public class GetUserBooksByPageHandler : IRequestHandler<GetUserBooksByPageQuery, List<BookDto>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public GetUserBooksByPageHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task<List<BookDto>> Handle(GetUserBooksByPageQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.getUserBooksByPage(request);
            var bookDtos = _mapper.Map<List<BookDto>>(books);
            return bookDtos;
        }
    }
}

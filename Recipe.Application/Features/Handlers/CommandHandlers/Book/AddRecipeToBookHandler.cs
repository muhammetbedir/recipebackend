using AutoMapper;
using MediatR;
using Recipe.Application.Dtos.Book;
using Recipe.Application.Features.Commands.Book;
using Recipe.Application.Interfaces.Repository;
using Recipe.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.Features.Handlers.CommandHandlers.Book
{
    public class AddRecipeToBookHandler : IRequestHandler<AddRecipeToBookCommand, BookDto>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public AddRecipeToBookHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task<BookDto> Handle(AddRecipeToBookCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<BookEntity>(request);
            await _bookRepository.InsertAsync(entity);
            await _bookRepository.CommitAsync();
            var response = _mapper.Map<BookDto>(entity);
            return response;
        }
    }
}

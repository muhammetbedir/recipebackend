using AutoMapper;
using MediatR;
using Recipe.Application.Features.Commands.Book;
using Recipe.Application.Interfaces.Repository;

namespace Recipe.Application.Features.Handlers.CommandHandlers.Book
{
    public class DeleteRecipeFromBookHandler : IRequestHandler<DeleteRecipeFromBookCommand>
    {
        private readonly IBookRepository _bookRepository;

        public DeleteRecipeFromBookHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task Handle(DeleteRecipeFromBookCommand request, CancellationToken cancellationToken)
        {
            await _bookRepository.deleteByIdAsync(request.Id);
            await _bookRepository.CommitAsync();
        }
    }
}

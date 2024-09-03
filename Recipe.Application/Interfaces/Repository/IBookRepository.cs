using Recipe.Application.Features.Queries.Book;
using Recipe.Application.Repository;
using Recipe.Domain.Models;

namespace Recipe.Application.Interfaces.Repository
{
    public interface IBookRepository : IGenericRepository<BookEntity>
    {
        Task<List<BookEntity>> getUserBooksByPage(GetUserBooksByPageQuery request);
    }
}

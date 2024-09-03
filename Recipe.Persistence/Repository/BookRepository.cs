using Microsoft.EntityFrameworkCore;
using Recipe.Application.Features.Queries.Book;
using Recipe.Application.Interfaces.Repository;
using Recipe.Domain.Models;
using Recipe.Infrastructure.Persistence;

namespace Recipe.Persistence.Repository
{
    public class BookRepository : GenericRepository<BookEntity>, IBookRepository
    {
        public BookRepository(RecipeAppDbContext context) : base(context)
        {
        }
        public async Task<List<BookEntity>> getUserBooksByPage(GetUserBooksByPageQuery request)
        {
            var data = _context.Books
                .Where(x => x.UserId == request.UserId)
                .Skip(request.Page * request.Count)
                .Take(request.Count);
            await data.Include(x => x.Recipe).LoadAsync();
            return await data.ToListAsync();
        }
    }
}

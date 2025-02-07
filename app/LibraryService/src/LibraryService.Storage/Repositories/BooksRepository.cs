using LibraryService.Common.Models;
using LibraryService.Storage.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace LibraryService.Storage.Repositories;

public class BooksRepository(PostgresContext db) : IBooksRepository
{
    public async Task<List<Book>> GetBooksListAsync(IEnumerable<Guid> booksUids)
    {
        var list = new List<Book>(booksUids.Count());
        foreach (var booksUid in booksUids)
        {
            var book = await db.Books.FirstOrDefaultAsync(b => b.BookUid == booksUid);
            list.Add(book);
        }

        return list;
    }
}
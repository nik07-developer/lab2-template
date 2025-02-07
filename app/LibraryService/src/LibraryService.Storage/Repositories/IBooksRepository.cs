using LibraryService.Common.Models;

namespace LibraryService.Storage.Repositories;

public interface IBooksRepository
{
    Task<List<Book>> GetBooksListAsync(IEnumerable<Guid> booksUids);
}
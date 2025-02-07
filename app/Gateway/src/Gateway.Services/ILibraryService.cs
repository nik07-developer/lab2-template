using Common.Models.DTO;
using Common.Models.Enums;

namespace Gateway.Services;

public interface ILibraryService
{
    Task<LibraryPaginationResponse?> GetLibrariesInCityAsync(string city, int page, int size);
    Task<LibraryBookPaginationResponse?> GetBooksInLibraryAsync(
        string libraryUid, int page, int size, bool showAll = false);

    Task<List<LibraryResponse>?> GetLibrariesListAsync(IEnumerable<Guid> librariesUid);
    Task<List<BookInfo>?> GetBooksListAsync(IEnumerable<Guid> booksUid);
    Task<bool> TakeBookAsync(Guid libraryUid, Guid bookUid);
    Task<UpdateBookConditionResponse?> ReturnBookAsync(Guid libraryUid, Guid bookUid, BookCondition condition);
}
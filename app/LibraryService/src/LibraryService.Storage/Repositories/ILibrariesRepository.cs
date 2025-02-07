using Common.Models.Enums;
using LibraryService.Common.Models;

namespace LibraryService.Storage.Repositories;

public interface ILibrariesRepository
{
    Task<int> GetTotalElementCountAsync();
    Task<int> GetTotaBooksCountByLibraryAsync(Guid libraryUid);
    Task<List<Library>> GetLibrariesInCityAsync(string city, int page = 1, int size = Int32.MaxValue);
    Task<List<LibraryBooks>> GetBooksInLibraryAsync(
        Guid libraryUid, int page = 1, int size = Int32.MaxValue, bool showAll = false);

    Task<List<Library>> GetLibrariesListAsync(IEnumerable<Guid> librariesUids);
    Task<bool> TakeBookAsync(Guid libraryUid, Guid bookUid);
    
    Task<BookCondition> ReturnBookAsync(Guid libraryUid, Guid bookUid, BookCondition condition);
}
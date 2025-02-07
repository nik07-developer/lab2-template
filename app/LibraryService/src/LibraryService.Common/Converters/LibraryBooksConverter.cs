using Common.Models.DTO;
using LibraryService.Common.Models;

namespace LibraryService.Common.Converters;

public static class LibraryBooksConverter
{
    public static LibraryBookResponse ConvertAppModelToDto(this LibraryBooks libraryBooks)
    {
        return new LibraryBookResponse()
        {
            BookUid = libraryBooks.Book.BookUid,
            Name = libraryBooks.Book.Name,
            Author = libraryBooks.Book.Author,
            Genre = libraryBooks.Book.Genre,
            Condition = libraryBooks.Book.Condition,
            AvailableCount = libraryBooks.AvailableCount
        };
    }
}
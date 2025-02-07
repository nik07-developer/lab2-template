using Common.Models.DTO;
using LibraryService.Common.Models;

namespace LibraryService.Common.Converters;

public static class BookConverter
{
    public static BookInfo ConvertAppModelToDto(this Book book)
    {
        return new BookInfo()
        {
            BookUid = book.BookUid,
            Name = book.Name,
            Author = book.Author,
            Genre = book.Genre,
        };
    }
}
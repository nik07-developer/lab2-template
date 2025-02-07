using Common.Models.DTO;
using LibraryService.Common.Models;

namespace LibraryService.Common.Converters;

public static class LibraryConverter
{
    public static LibraryResponse ConvertAppModelToDto(this Library library)
    {
        return new LibraryResponse()
        {
            LibraryUid = library.LibraryUid.ToString(),
            Name = library.Name,
            Address = library.Address,
            City = library.City
        };
    }
}
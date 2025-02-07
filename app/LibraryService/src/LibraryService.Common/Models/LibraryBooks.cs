namespace LibraryService.Common.Models;

public class LibraryBooks
{
    public int BookId { get; set; }
    public Book Book { get; set; }

    public int LibraryId { get; set; }
    public Library Library { get; set; }

    public int AvailableCount { get; set; }
}
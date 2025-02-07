namespace LibraryService.Common.Models;

public class Library
{
    public int Id { get; set; }
    public Guid LibraryUid { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public string Address { get; set; }

    public List<LibraryBooks> LibraryBooks { get; set; }
}
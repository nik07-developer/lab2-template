using System.Runtime.Serialization;

namespace Common.Models.DTO;

public class LibraryBookPaginationResponse
{
    [DataMember(Name="page")]
    public int? Page { get; set; }

    [DataMember(Name="pageSize")]
    public int? PageSize { get; set; }

    [DataMember(Name="totalElements")]
    public int TotalElements { get; set; }

    [DataMember(Name="items")]
    public List<LibraryBookResponse> Items { get; set; }
}
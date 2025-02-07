using Common.Models.DTO;

namespace Gateway.Services;

public interface IReservationService
{
    Task<List<RawBookReservationResponse>?> GetUserReservationsAsync(string xUserName);
    Task<RawBookReservationResponse?> TakeBook(string xUserName, TakeBookRequest body);
    Task<RawBookReservationResponse?>  ReturnBook(Guid reservationUid, DateOnly date);
}
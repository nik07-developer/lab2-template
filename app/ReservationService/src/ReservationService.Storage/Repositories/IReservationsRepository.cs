using ReservationService.Common.Models;

namespace ReservationService.Storage.Repositories;

public interface IReservationsRepository
{
    Task<List<Reservation>> GetUserReservationsAsync(string userName);

    Task<Reservation> CreateReservationAsync(
        string userName, Guid bookUid, Guid libraryUid, DateOnly tillDate);

    Task<Reservation?> ReturnBookAsync(Guid reservationUid, DateOnly tillDate);
}
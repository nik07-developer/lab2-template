using Common.Models.DTO;
using ReservationService.Common.Models;

namespace ReservationService.Common.Converters;

public static class ReservationConverter
{
    public static RawBookReservationResponse ConvertAppModelToDto(this Reservation reservation)
    {
        return new RawBookReservationResponse()
        {
            ReservationUid = reservation.ReservationUid,
            Username = reservation.Username,
            BookUid = reservation.BookUid,
            LibraryUid = reservation.LibraryUid,
            Status = reservation.Status,
            StartDate = reservation.StartDate,
            TillDate = reservation.TillDate
        };
    }
}
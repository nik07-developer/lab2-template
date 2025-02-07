using Common.Models.Enums;
using Microsoft.EntityFrameworkCore;
using ReservationService.Common.Models;
using ReservationService.Storage.DbContexts;

namespace ReservationService.Storage.Repositories;

public class ReservationsRepository(PostgresContext db) : IReservationsRepository
{
    public async Task<List<Reservation>> GetUserReservationsAsync(string userName)
    {
        return await db.Reservations.Where(r => r.Username == userName).ToListAsync();
    }
    
    public async Task<Reservation> CreateReservationAsync(
        string userName, Guid bookUid, Guid libraryUid, DateOnly tillDate)
    {
        var reservation = new Reservation()
        {
            Id = 0,
            ReservationUid = Guid.NewGuid(),
            Username = userName,
            BookUid = bookUid,
            LibraryUid = libraryUid,
            Status = ReservationStatus.RENTED,
            StartDate = DateOnly.FromDateTime(DateTime.Now),
            TillDate = tillDate
        };
        
        reservation = (await db.Reservations.AddAsync(reservation)).Entity;
        await db.SaveChangesAsync();
        return reservation;
    }
    
    public async Task<Reservation?> ReturnBookAsync(Guid reservationUid, DateOnly tillDate)
    {
        var reservation = await db.Reservations
            .FirstOrDefaultAsync(r => r.ReservationUid == reservationUid);

        if (reservation == null)
            return null;

        if (tillDate > reservation.TillDate)
            reservation.Status = ReservationStatus.EXPIRED;
        else
            reservation.Status = ReservationStatus.RETURNED;

        await db.SaveChangesAsync();
        return reservation;
    }
}
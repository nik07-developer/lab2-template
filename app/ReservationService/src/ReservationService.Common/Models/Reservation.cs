using System.ComponentModel.DataAnnotations;
using Common.Models.Enums;

namespace ReservationService.Common.Models;

public class Reservation
{
    public int Id { get; set; }

    [Required]
    public Guid ReservationUid { get; set; }

    [Required]
    [MaxLength(80)]
    public string Username { get; set; }

    [Required]
    public Guid BookUid { get; set; }

    [Required]
    public Guid LibraryUid { get; set; }

    [Required]
    public ReservationStatus Status { get; set; }

    [Required]
    public DateOnly StartDate { get; set; }

    [Required]
    public DateOnly TillDate { get; set; }
}
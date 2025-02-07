using System.ComponentModel.DataAnnotations;
using System.Net;
using Common.Models.DTO;
using ReservationService.Storage.Repositories;
using Microsoft.AspNetCore.Mvc;
using ReservationService.Common.Converters;

namespace ReservationService.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ReservationsController(IReservationsRepository reservationsRepository) : Controller
{
    [HttpGet("/manage/health")]
    public IActionResult Health()
    {
        return Ok();
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(List<RawBookReservationResponse>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetUserReservations([FromHeader(Name = "X-User-Name")][Required] string xUserName)
    {
        try
        {
            var reservations = await reservationsRepository.GetUserReservationsAsync(xUserName);
            return Ok(reservations.Select(r => r.ConvertAppModelToDto()).ToList());
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e);
        }
    }
    
    [HttpPost()]
    [ProducesResponseType(typeof(RawBookReservationResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> TakeBook(
        [FromHeader(Name = "X-User-Name")][Required] string xUserName, [FromBody][Required] TakeBookRequest body)
    {
        try
        {
            var reservations = await reservationsRepository.CreateReservationAsync(
                userName: xUserName,
                bookUid: body.BookUid,
                libraryUid: body.LibraryUid,
                tillDate: body.TillDate);
            
            return Ok(reservations);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e);
        }
    }
    
    [HttpPatch("{reservationUid}/return")]
    [ProducesResponseType(typeof(RawBookReservationResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> ReturnBook([FromRoute] Guid reservationUid, [FromBody] DateOnly date)
    {
        try
        {
            var reservation = await reservationsRepository.ReturnBookAsync(reservationUid, date);
            if (reservation == null)
                return NotFound(new ErrorResponse("Бронирование не найдено"));
            
            return Ok(reservation.ConvertAppModelToDto());
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e);
        }
    }
}
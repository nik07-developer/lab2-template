using System.ComponentModel.DataAnnotations;

namespace RatingService.Common.Models;

public class Rating
{
    public int Id { get; set; }

    [Required]
    [StringLength(80)]
    public string Username { get; set; }

    [Required]
    [Range(0, 100)]
    public int Stars { get; set; }
}
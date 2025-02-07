using Common.Models.DTO;
using RatingService.Common.Models;

namespace RatingService.Common.Converters;

public static class RatingConverter
{
    public static UserRatingResponse ConvertAppModelToDto(this Rating rating)
    {
        return new UserRatingResponse() { Stars = rating.Stars };
    }
}
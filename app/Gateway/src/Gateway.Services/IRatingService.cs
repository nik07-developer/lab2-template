using Common.Models.DTO;

namespace Gateway.Services;

public interface IRatingService
{
    Task<UserRatingResponse?> GetUserRating(string xUserName);
    Task<UserRatingResponse?> IncreaseRating(string xUserName);
    Task<UserRatingResponse?> DecreaseRating(string xUserName);
}
using RatingService.Common.Models;

namespace RatingService.Storage.Repositories;

public interface IRatingsRepository
{
    Task<Rating?> GetUserRatingAsync(string userName);
    Task<Rating?> AddNewUserAsync(string userName);
    Task<Rating?> IncreaseRatingAsync(string userName);
    Task<Rating?> DecreaseRatingAsync(string userName);
}
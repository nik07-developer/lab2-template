using Microsoft.EntityFrameworkCore;
using RatingService.Common.Models;
using RatingService.Storage.DbContexts;

namespace RatingService.Storage.Repositories;

public class RatingsRepository(PostgresContext db) : IRatingsRepository
{
    public async Task<Rating?> GetUserRatingAsync(string userName)
    {
        return await db.Ratings.FirstOrDefaultAsync(r => r.Username == userName);
    }
    
    public async Task<Rating?> AddNewUserAsync(string userName)
    {
        var rating = (await db.Ratings.AddAsync(new Rating()
        {
            Id = 0,
            Username = userName,
            Stars = 75
        })).Entity;
        
        await db.SaveChangesAsync();
        return rating;
    }

    public async Task<Rating?> IncreaseRatingAsync(string userName)
    {
        var rating = await db.Ratings.FirstOrDefaultAsync(r => r.Username == userName);
        if (rating == null)
            return null;

        rating.Stars += 1;
        
        await db.SaveChangesAsync();
        return rating;
    }

    public async Task<Rating?> DecreaseRatingAsync(string userName)
    {
        var rating = await db.Ratings.FirstOrDefaultAsync(r => r.Username == userName);
        if (rating == null)
            return null;

        rating.Stars -= 10;
        
        await db.SaveChangesAsync();
        return rating;
    }
}
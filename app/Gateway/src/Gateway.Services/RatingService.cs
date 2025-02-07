using Common.Models.DTO;

namespace Gateway.Services;

public class RatingService(IHttpClientFactory httpClientFactory, string baseUrl)
    : BaseHttpService(httpClientFactory, baseUrl), IRatingService
{
    public async Task<UserRatingResponse?> GetUserRating(string xUserName)
    {
        var method = $"/api/v1/rating";
        return await GetAsync<UserRatingResponse>(method,
            new Dictionary<string, string>()
            {
                { "X-User-Name", xUserName }
            });
    }

    public async Task<UserRatingResponse?> IncreaseRating(string xUserName)
    {
        var method = $"/api/v1/rating/increase";
        return await PatchAsync<UserRatingResponse>(method,
            headers: new Dictionary<string, string>()
            {
                { "X-User-Name", xUserName }
            });
    }

    public async Task<UserRatingResponse?> DecreaseRating(string xUserName)
    {
        var method = $"/api/v1/rating/decrease";
        return await PatchAsync<UserRatingResponse>(method,
            headers: new Dictionary<string, string>()
            {
                { "X-User-Name", xUserName }
            });
    }
}
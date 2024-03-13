using System.Security.Claims;

namespace AS.ApplicationServices.Utilities
{
    public static class ClaimsPrincipalExtensions
    {
        public static int GetUserId(this ClaimsPrincipal user)
        {
            string? userIdStr = user.Claims.Where(c => c.Type == "UserId")
                .Select(x => x.Value)
                .FirstOrDefault();

            int userId = 0;
            int.TryParse(userIdStr, out userId);

            return userId;
        }
        public static bool GetIsPremium(this ClaimsPrincipal user)
        {
            string? isPremiumStr = user.Claims.Where(c => c.Type == "IsPremium")
                .Select(x => x.Value)
                .FirstOrDefault();

            bool isPremium = false;
            bool.TryParse(isPremiumStr, out isPremium);

            return isPremium;
        }
        public static int GetRating(this ClaimsPrincipal user)
        {
            string? ratingStr = user.Claims.Where(c => c.Type == "Rating")
                .Select(x => x.Value)
                .FirstOrDefault();

            int rating = 0;
            int.TryParse(ratingStr, out rating);

            return rating;
        }
    }
}

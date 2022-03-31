namespace SimpleBlog.Infrastructure.CacheKeys
{
    public class VoteCacheKey
    {
        public static string ListKey => "VoteList";

        public static string SelectListKey => "VoteSelectList";

        public static string GetKey(int voteId) => $"Vote-{voteId}";

        public static string GetDetailsKey(int voteId) => $"VoteDetails-{voteId}";
    }
}
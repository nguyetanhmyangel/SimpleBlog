namespace SimpleBlog.Infrastructure.CacheKeys
{
    public class ArticleCacheKey
    {
        public static string ListKey => "ArticleFunctionList";

        public static string SelectListKey => "ArticleSelectList";

        public static string GetKey(int articleId) => $"Article-{articleId}";

        public static string GetDetailsKey(int articleId) => $"ArticleDetails-{articleId}";
    }
}
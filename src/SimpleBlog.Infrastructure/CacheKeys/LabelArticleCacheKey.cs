namespace SimpleBlog.Infrastructure.CacheKeys
{
    public class LabelArticleCacheKey
    {
        public static string ListKey => "LabelArticleList";

        public static string SelectListKey => "LabelArticleSelectList";

        public static string GetKey(int labelArticleId) => $"LabelArticle-{labelArticleId}";

        public static string GetDetailsKey(int labelArticleId) => $"LabelArticleDetails-{labelArticleId}";
    }
}
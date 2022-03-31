namespace SimpleBlog.Infrastructure.CacheKeys
{
    public class LabelCacheKey
    {
        public static string ListKey => "LabelList";

        public static string SelectListKey => "LabelSelectList";

        public static string GetKey(int labelId) => $"Label-{labelId}";

        public static string GetDetailsKey(int labelId) => $"LabelDetails-{labelId}";
    }
}
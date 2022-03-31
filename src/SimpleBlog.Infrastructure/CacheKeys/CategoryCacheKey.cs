namespace SimpleBlog.Infrastructure.CacheKeys
{
    public class CategoryCacheKey
    {
        public static string ListKey => "CategoryList";

        public static string SelectListKey => "CategorySelectList";

        public static string GetKey(int categoryId) => $"Category-{categoryId}";

        public static string GetDetailsKey(int categoryId) => $"CategoryDetails-{categoryId}";
    }
}
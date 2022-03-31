namespace SimpleBlog.Infrastructure.CacheKeys
{
    public class FunctionCacheKey
    {
        public static string ListKey => "FunctionList";

        public static string SelectListKey => "FunctionSelectList";

        public static string GetKey(int functionId) => $"Function-{functionId}";

        public static string GetDetailsKey(int functionId) => $"FunctionDetails-{functionId}";
    }
}
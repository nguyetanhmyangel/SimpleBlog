namespace SimpleBlog.Infrastructure.CacheKeys
{
    public static class AppCommandCacheKeys
    {
        public static string ListKey => "AppCommandList";

        public static string SelectListKey => "AppCommandSelectList";

        public static string GetKey(int appCommandId) => $"AppCommand-{appCommandId}";

        public static string GetDetailsKey(int appCommandId) => $"AppCommandDetails-{appCommandId}";
    }
}
namespace SimpleBlog.Infrastructure.CacheKeys
{
    public class ReportCacheKey
    {
        public static string ListKey => "ReportList";

        public static string SelectListKey => "ReportSelectList";

        public static string GetKey(int reportId) => $"Report-{reportId}";

        public static string GetDetailsKey(int reportId) => $"ReportDetails-{reportId}";
    }
}
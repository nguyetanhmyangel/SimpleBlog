using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlog.Infrastructure.CacheKeys
{
    public class AppPermissionCacheKey
    {
        public static string ListKey => "AppCommandFunctionList";

        public static string SelectListKey => "AppCommandFunctionSelectList";

        public static string GetKey(int appCommandFunctionId) => $"AppCommandFunction-{appCommandFunctionId}";

        public static string GetDetailsKey(int appCommandFunctionId) => $"AppCommandFunctionDetails-{appCommandFunctionId}";
    }
}

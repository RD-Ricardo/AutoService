using Microsoft.AspNetCore.Http;

namespace AutoService.Infrastructure.Audit
{
    public interface IAuditHelper
    {
        void RegisterLog(HttpContext context, string description = null, string model = null);
    }
}

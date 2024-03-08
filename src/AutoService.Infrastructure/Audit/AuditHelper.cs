using Microsoft.AspNetCore.Http;

namespace AutoService.Infrastructure.Audit
{
    public class AuditHelper : IAuditHelper
    {
        public void RegisterLog(HttpContext context, string description = null, string model = null)
        {
            throw new NotImplementedException();
        }
    }
}

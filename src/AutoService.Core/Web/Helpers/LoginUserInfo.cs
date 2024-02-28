using Microsoft.AspNetCore.Mvc;

namespace AutoService.Core.Web.Helpers
{
    public static class LoginUserInfo
    {
        public static string ReturnUserEmail(this ControllerBase controller)
        {
            var userEmail = controller.ControllerContext.HttpContext
                .User.Claims.FirstOrDefault(o => o.Type.Equals("Email"));

            return Convert.ToString(userEmail.Value);
        }

        public static Guid ReturnUserId(this ControllerBase controller)
        {
            var user = controller.ControllerContext.HttpContext
                 .User.Claims.FirstOrDefault(o => o.Type.Equals("ProfessionalId"));

            return Guid.Parse(user.Value);
        }
    }
}

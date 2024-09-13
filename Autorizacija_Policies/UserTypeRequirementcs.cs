using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace VjencanjeIzSnova_WebApp.Autorizacija_Policies
{
    public class UserTypeRequirement : IAuthorizationRequirement
    {
        public string RequiredUserType { get; }

        public UserTypeRequirement(string userType)
        {
            RequiredUserType = userType;
        }
    }

    public class UserTypeHandler : AuthorizationHandler<UserTypeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserTypeRequirement requirement)
        {
            if (context.User.Identity is ClaimsIdentity identity)
            {
                var userTypeClaim = identity.FindFirst("UserType");
                if (userTypeClaim != null && userTypeClaim.Value == requirement.RequiredUserType)
                {
                    context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;
        }
    }


}

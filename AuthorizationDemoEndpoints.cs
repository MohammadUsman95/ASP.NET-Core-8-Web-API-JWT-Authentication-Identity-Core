using Microsoft.AspNetCore.Authorization;

namespace AuthECAPI.Controllers
{
    public static class AuthorizationDemoEndpoints
    {
        public static IEndpointRouteBuilder MapAuthorizationDemoEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/AdminOnly", AdminOnly);
            app.MapGet("/AdminOrTeacher", [Authorize(Roles = "Admin,Teacher")] () =>
            {
                return "Admin or Teacher";
            });

            app.MapGet("/LibraryMembersOnly", [Authorize(Policy = "HaSLibraryId")] () =>
            {
                return "Library Members Only";
            });
            app.MapGet("/ApplyForMaternityLeave", [Authorize(Roles = "Teacher", Policy = "FemalesOnly")] () =>
            {
                return "Applied for maternity leave";
            });

            return app;          
        }

        [Authorize(Roles = "Admin")]
        private static string AdminOnly() 
        {
            return "Admin Only";
        }
    }
}

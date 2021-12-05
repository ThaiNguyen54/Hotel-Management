using Hotel_Management_Project.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System.Web;


namespace Hotel_Management_Project.secutity
{
    public class DeatAuthorizeAttribute : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var current = UserCurrent.isActive;
            if (!current&&UserCurrent.userName==null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index", area = "Admin" }));
            }
        }
    }
}
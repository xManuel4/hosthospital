
using hosthospital.Core.Application.Dtos.Account;
using Microsoft.AspNetCore.Http;
using hosthospital.Core.Application.Helpers;
namespace hosthospitalv1.Middleware
{
    public class validateUserSession
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public validateUserSession(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool HasUser(string userId) 
        {
            AuthenticationResponse authenticationResponse = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");
            if (authenticationResponse == null) { 
            
            return false;
            
            }

            return true;
        }

    }
}

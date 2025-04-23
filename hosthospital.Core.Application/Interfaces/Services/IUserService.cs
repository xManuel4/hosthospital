using hosthospital.Core.Application.Dtos.Account;
using hosthospital.Core.Application.Dtos.Account;
using hosthospital.Core.Application.ViewModels.User;
using hosthospital.Core.Application.ViewModels.User;
using hosthospital.Core.Application.ViewModels.User;

namespace hosthospital.Core.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<string> ConfirmEmailAsync(string userId, string token);
        Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordViewModel vm, string origin);
        Task<AuthenticationResponse> LoginAsync(LoginViewModel vm);
        Task<RegisterResponse> RegisterAsync(SaveUserViewnModel vm, string origin);
        Task<ResetPasswordResponse> ResetPasswordAsync(ResetPasswordViewModel vm);
        Task SignOutAsync();
    }
}
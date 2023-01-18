using Google.Apis.Auth.OAuth2;

namespace Notification.Service
{
    public interface IGoogleAuthService
    {
        Task<UserCredential?> DoAuth();
    }
}

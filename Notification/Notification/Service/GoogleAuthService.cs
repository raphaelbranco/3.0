using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;
using System.Globalization;

namespace Notification.Service
{
    public class GoogleAuthService : IGoogleAuthService
    {
        private IConfiguration _configuration;

        public GoogleAuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<UserCredential?> DoAuth()
        {
            string[] scopes = { "https://mail.google.com/" };
            
            string credPath = "token.json";
            UserCredential credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
            new ClientSecrets
            {
                ClientId = _configuration.GetValue<string>("installed:client_id"),
                ClientSecret = _configuration.GetValue<string>("installed:client_secret")
            },
            scopes,
            "user",
            CancellationToken.None,
            new FileDataStore(credPath, true));


            return credential;
        }
    }
}

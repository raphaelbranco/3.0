using Base30.Core.Messages.IntegrationEvents;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;

namespace Notification.Service
{
    public class SendMailService: ISendMailService
    {
        private readonly IGoogleAuthService _googleAuthService;

        public SendMailService(IGoogleAuthService googleAuthService)
        {
            _googleAuthService = googleAuthService;
        }

        public async Task<bool> SendAsync(SendEmailEvent mailEvent)
        {
            UserCredential? credential = await _googleAuthService.DoAuth();

            if (credential == null) return false;

            return SendEmail(credential, mailEvent);
        }

        private bool SendEmail(UserCredential credential, SendEmailEvent mailEvent)
        {
            // Create Gmail API service.
            var service = new GmailService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = "OauthDesktop"
            });

            //Parsing HTML 
            string strDate = DateTime.Now.ToString();
            string strTo = mailEvent.Mensagem;
            string message = $"To: {strTo}\r\nSubject: {strTo}\r\nContent-Type: text/html;charset=utf-8\r\n\r\n{strDate}";
            var newMsg = new Message();
            newMsg.Raw = this.Base64UrlEncode(message.ToString());
            Message response = service.Users.Messages.Send(newMsg, "me").Execute();

            if (response != null)
                return true;
            else
                return false;
        }

        private string Base64UrlEncode(string input)
        {
            var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            // Special "url-safe" base64 encode.
            return Convert.ToBase64String(inputBytes)
              .Replace('+', '-')
              .Replace('/', '_')
              .Replace("=", "");
        }

    }
}

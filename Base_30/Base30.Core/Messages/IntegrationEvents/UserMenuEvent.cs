namespace Base30.Core.Messages.IntegrationEvents
{
    public class UserMenuEvent :Event
    {
        public string Mensagem { get; private set; }

        public UserMenuEvent(string mensagem)
        {
            Mensagem= mensagem;
        }
    }
}

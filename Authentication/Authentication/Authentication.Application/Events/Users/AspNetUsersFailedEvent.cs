using Base30.Core.Messages;

namespace Base30.Authentication.Application.Events.AspNetUsers
{
    public class AspNetUsersFailedEvent : Event
    {
        public string Error { get; private set; }

        public AspNetUsersFailedEvent(string err)
        {
            Error = err;
        }
    }
}


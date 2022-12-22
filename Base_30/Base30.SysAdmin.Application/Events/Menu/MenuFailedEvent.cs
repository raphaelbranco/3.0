using Base30.Core.Messages;

namespace Base30.SysAdmin.Application.Events.Menu
{
    public class MenuFailedEvent : Event
    {
        public string Error { get; private set; }

        public MenuFailedEvent(string err)
        {
            Error= err;
        }
    }
}

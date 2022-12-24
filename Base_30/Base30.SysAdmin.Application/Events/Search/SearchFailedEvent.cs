using Base30.Core.Messages;

namespace Base30.SysAdmin.Application.Events.Search
{
    public class SearchFailedEvent : Event
    {
        public string Error { get; private set; }

        public SearchFailedEvent(string err)
        {
            Error = err;
        }
    }
}


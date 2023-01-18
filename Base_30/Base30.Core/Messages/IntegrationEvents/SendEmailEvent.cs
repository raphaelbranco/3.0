using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base30.Core.Messages.IntegrationEvents
{
    public class SendEmailEvent : Event
    {
        public string Mensagem { get; private set; }

        public SendEmailEvent(string mensagem)
        {
            Mensagem = mensagem;
        }
    }
}

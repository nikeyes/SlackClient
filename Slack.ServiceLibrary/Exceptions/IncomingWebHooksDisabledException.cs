using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slack.ServiceLibrary.Exceptions
{
    public class IncomingWebHookDisabledException: Exception
    {
        public IncomingWebHookDisabledException():base()
        {
        }

        public IncomingWebHookDisabledException(String message, Exception innerException) : base(message, innerException)
        {
        }

    }
}

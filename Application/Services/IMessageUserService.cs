using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public interface IMessageUserService
    {
        bool SendMessage(string message, string subject, string recipient);
    }
}

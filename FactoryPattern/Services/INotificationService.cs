using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern
{
    public interface INotificationService
    {
        void Send(string recipient, string message);
    }
}

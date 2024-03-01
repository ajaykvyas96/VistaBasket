using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VistaBasket.MessageBus
{
    public interface IMessageBus
    {
        Task publishMessage();
        Task PublishMessageAsync(string message);
    }
}

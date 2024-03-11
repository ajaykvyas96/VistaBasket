using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VistaBasket.Auth.Service.Interface
{
    public interface IMessageBus
    {
        Task publishMessage();
    }
}

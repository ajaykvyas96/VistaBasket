using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vistabasket.Inventory.Service.Interface
{
    public interface IUserService
    {
        string GetCurrentUserId();
        void SetCurrentUserId(string userId);
    }
}

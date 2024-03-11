using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vistabasket.Inventory.Service.Interface;

namespace Vistabasket.Inventory.Service.Service
{
    public class UserService : IUserService
    {
        private string _currentUserId;

        public string GetCurrentUserId()
        {
            return _currentUserId;
        }

        public void SetCurrentUserId(string userId)
        {
            _currentUserId = userId;
        }
    }
}

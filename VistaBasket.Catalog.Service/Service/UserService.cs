using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VistaBasket.Catalog.Service.Interface;

namespace VistaBasket.Catalog.Service.Service
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

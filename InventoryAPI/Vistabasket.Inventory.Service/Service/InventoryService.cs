using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vistabasket.Inventory.Data;
using Vistabasket.Inventory.Service.Interface;
using Vistabasket.Inventory.Service.Model.Supplier;
using VistaBasket.Common.Repository;

namespace Vistabasket.Inventory.Service.Service
{
    public class InventoryService : IInventoryService
    {
        private readonly IUnitOfWork<InventoryDbContext> _unitOfWork;
        public InventoryService(IUnitOfWork<InventoryDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<int> GetProductsBelowReorderLevel()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SupplierDto> GetProductSuppliers(int productId)
        {
            throw new NotImplementedException();
        }

        public int GetStockLevel(int productId)
        {
            throw new NotImplementedException();
        }

        public void PlacePurchaseOrder(int productId, int quantity)
        {
            throw new NotImplementedException();
        }

        public void ReceiveShipment(int productId, int quantity)
        {
            throw new NotImplementedException();
        }

        public bool ReleaseReservedStock(int productId, int quantity)
        {
            throw new NotImplementedException();
        }

        public void ReplenishStock(int productId, int quantity)
        {
            throw new NotImplementedException();
        }

        public bool ReserveStock(int productId, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vistabasket.Inventory.Service.Model.Supplier;

namespace Vistabasket.Inventory.Service.Interface
{
    public interface IInventoryService
    {
        // Retrieve current stock level for a specific product
        int GetStockLevel(int productId);

        // Reserve a quantity of a product for an order
        bool ReserveStock(int productId, int quantity);

        // Release reserved stock for a canceled or failed order
        bool ReleaseReservedStock(int productId, int quantity);

        // Increase stock level due to a new shipment
        void ReplenishStock(int productId, int quantity);

        // Get a list of products below the reorder level
        IEnumerable<int> GetProductsBelowReorderLevel();

        // Place a purchase order to restock products
        void PlacePurchaseOrder(int productId, int quantity);

        // Receive a shipment from a supplier and update stock levels
        void ReceiveShipment(int productId, int quantity);
        // Get information about a product's suppliers
        IEnumerable<SupplierDto> GetProductSuppliers(int productId);
    }
}

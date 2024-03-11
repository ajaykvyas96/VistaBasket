using Microsoft.EntityFrameworkCore;
using VistaBasket.Common.Repository;
using Vistabasket.Inventory.Entities.Entities;
using System.Reflection.Emit;

namespace Vistabasket.Inventory.Data
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SupplierProduct>()
            .HasOne(sp => sp.Supplier)
            .WithMany(s => s.SupplierProducts)
            .HasForeignKey(sp => sp.SupplierID);

            base.OnModelCreating(builder);
        }
        public DbSet<ProductInventory> ProductInventory { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierProduct> SupplierProducts { get; set; }
        public virtual async Task<int> SaveChangesAsync(string userId = null!)
        {
            DateTime now = DateTime.Now;
            foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry changedEntity in ChangeTracker.Entries())
            {

                if (changedEntity.Entity is BaseEntity entity)
                {
                    switch (changedEntity.State)
                    {
                        case EntityState.Added:
                            entity.CreatedOn = DateTime.Now.ToUniversalTime();
                            entity.CreatedBy = userId;
                            entity.UpdatedOn = DateTime.Now.ToUniversalTime();
                            entity.IsActive = true;
                            break;
                        case EntityState.Modified:
                            Entry(entity).Property(x => x.UpdatedOn).IsModified = false;
                            entity.UpdatedOn = DateTime.Now.ToUniversalTime();
                            entity.UpdatedBy = userId;
                            break;
                        case EntityState.Deleted:
                            entity.UpdatedOn = DateTime.Now.ToUniversalTime();
                            entity.UpdatedBy = userId;
                            entity.IsActive = false;
                            break;
                    }
                }

            }
            //OnBeforeSaveChanges(userId);
            var result = await base.SaveChangesAsync();
            return result;
        }
    }
}

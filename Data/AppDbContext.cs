using EcoLink.Models;
using EcoLink.Models.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EcoLink.Data
{
    public class AppDbContext:IdentityDbContext<ApplicationUser,IdentityRole<int>,int>
    {
       public AppDbContext(DbContextOptions<AppDbContext> option):base(option)
        {

        }

        public virtual  DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Factory> Factories { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<MaterialType> MaterialTypes { get; set; }
        public virtual DbSet<Bin> Bins { get; set; }
        public virtual DbSet<PickupRequest> PickupRequests { get; set; }
        public virtual DbSet<Wallet> Wallets { get; set; }
        public virtual DbSet<WalletTransaction> WalletTransactions { get; set; }
        public virtual DbSet<FactoryProduct> FactoryProducts { get; set; }
        public virtual DbSet<RewardOrder> RewardOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().HasQueryFilter(e => !e.IsDeleted);
            builder.Entity<Branch>().HasQueryFilter(e => !e.IsDeleted);
            builder.Entity<Factory>().HasQueryFilter(e => !e.IsDeleted);
            builder.Entity<Driver>().HasQueryFilter(e => !e.IsDeleted);
            builder.Entity<MaterialType>().HasQueryFilter(e => !e.IsDeleted);
            builder.Entity<Bin>().HasQueryFilter(e => !e.IsDeleted);
            builder.Entity<PickupRequest>().HasQueryFilter(e => !e.IsDeleted);
            builder.Entity<Wallet>().HasQueryFilter(e => !e.IsDeleted);
            builder.Entity<WalletTransaction>().HasQueryFilter(e => !e.IsDeleted);
            builder.Entity<FactoryProduct>().HasQueryFilter(e => !e.IsDeleted);
            builder.Entity<RewardOrder>().HasQueryFilter(e => !e.IsDeleted);
        }


  

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ApplyAuditRules();
            return base.SaveChangesAsync(cancellationToken);
        }



        private void ApplyAuditRules() { 
        
        
        var now = DateTime.UtcNow;

            foreach (var entry  in ChangeTracker.Entries<IAuditable>())
            {

                switch (entry.State) {

                    case EntityState.Added:
                        entry.Entity.CreatedAt = now;   
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = now;   
                        break;

                        case EntityState.Deleted:   
                        entry.State = EntityState.Modified;  
                        entry.Entity.IsDeleted = true;
                        entry.Entity.UpdatedAt = now;
                        break;
                
                }


            }
        
        
        
        }

    }
}
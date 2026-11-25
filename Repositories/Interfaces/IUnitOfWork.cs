using EcoLink.Models;

namespace EcoLink.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<Branch> Branches { get; }
        IGenericRepository<Factory> Factories { get; }
        IGenericRepository<Driver> Drivers { get; }
        IGenericRepository<MaterialType> MaterialTypes { get; }

        IGenericRepository<Bin> Bins { get; }
        IGenericRepository<PickupRequest> PickupRequests { get; }

        IGenericRepository<Wallet> Wallets { get; }
        IGenericRepository<WalletTransaction> WalletTransactions { get; }
        IGenericRepository<FactoryProduct> FactoryProducts { get; }
        IGenericRepository<RewardOrder> RewardOrders { get; }

        Task<int> CompleteAsync();
    }
}

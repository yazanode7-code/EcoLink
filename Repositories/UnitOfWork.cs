using EcoLink.Data;
using EcoLink.Models;
using EcoLink.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcoLink.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly AppDbContext _context;


        public UnitOfWork(AppDbContext context)
        {
            _context = context;

            Branches = new GenericRepository<Branch>(_context);

            Factories = new GenericRepository<Factory>(_context);
            Drivers = new GenericRepository<Driver>(_context);
            MaterialTypes = new GenericRepository<MaterialType>(_context);
            Bins = new GenericRepository<Bin>(_context);
            PickupRequests = new GenericRepository<PickupRequest>(_context);
            Wallets = new GenericRepository<Wallet>(_context);
            WalletTransactions = new GenericRepository<WalletTransaction>(_context);
            FactoryProducts = new GenericRepository<FactoryProduct>(_context);
            RewardOrders = new GenericRepository<RewardOrder>(_context);

        }

        public IGenericRepository<Branch> Branches {get;}

        public IGenericRepository<Factory> Factories { get; }
        public IGenericRepository<Driver> Drivers { get; }
        public IGenericRepository<MaterialType> MaterialTypes { get; }

        public IGenericRepository<Bin> Bins { get; }

        public IGenericRepository<PickupRequest> PickupRequests { get; }

        public IGenericRepository<Wallet> Wallets { get; }

        public IGenericRepository<WalletTransaction> WalletTransactions { get; }

        public IGenericRepository<FactoryProduct> FactoryProducts { get; }

        public IGenericRepository<RewardOrder> RewardOrders { get; }

        

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}

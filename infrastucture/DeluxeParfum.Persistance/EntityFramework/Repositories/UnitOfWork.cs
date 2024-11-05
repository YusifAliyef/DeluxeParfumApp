using DeluxeParfum.Application.Interfaces;
using DeluxeParfum.Domain.Entities.Common;
using DeluxeParfum.Persistance.EntityFramework.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Persistance.EntityFramework.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DeluxeParfumContext _context;
        private readonly Dictionary<Type, object> _repositories;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public UnitOfWork(DeluxeParfumContext context, IHttpContextAccessor httpContextAccessor)
        {
            _repositories=new Dictionary<Type, object>();
            _context = context;
            _context.Database.BeginTransactionAsync();
            _httpContextAccessor= httpContextAccessor;
           
        }

        public IProductRepository ProductRepository => SetRepository<IProductRepository>();

        public ICategoryRepository CategoryRepository => SetRepository<ICategoryRepository>();

        public IAddressRepository AddressRepository => SetRepository<IAddressRepository>();

        public ICardItemRepository CardItemRepository => SetRepository<ICardItemRepository>();

        public ICustomerRepository CustomerRepository => SetRepository<ICustomerRepository>();

        public IOrderRepository OrderRepository => SetRepository<IOrderRepository>();

        public IReviewRepository ReviewRepository => SetRepository<IReviewRepository>();
        public IUserRepository UserRepository => SetRepository<IUserRepository>();

        public IRoleRepository RoleRepository => SetRepository<IRoleRepository>();

        public IUserRoleRepository UserRoleRepository => SetRepository<IUserRoleRepository>();

        public async Task Commit()
        {
            var UserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            IEnumerable<EntityEntry<EditedBaseEntity>> entities = _context
                .ChangeTracker
                .Entries<EditedBaseEntity>()
                .ToList();

            foreach(var entry in entities)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedId = Convert.ToInt32(UserId);
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedId=Convert.ToInt32(UserId);
                }

            }

            await _context.SaveChangesAsync();
            await _context.Database.CommitTransactionAsync();


        }

        public TRepository GetRepository<TRepository>() where TRepository : class
        {
            throw new NotImplementedException();
        }

        public void RollBack()
        {
           foreach(var entry in _context.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:   
                        entry.Reload(); 
                        break;
                }
            }
        }

        public TRepository SetRepository<TRepository>()
        {
            if (_repositories.ContainsKey(typeof(TRepository)))
            {
                return (TRepository)_repositories[typeof(TRepository)];
            }

            var repositoryType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => !x.IsInterface && x.IsClass && x.IsAssignableTo(typeof(TRepository)));

            var repositoryInstance = (TRepository)Activator.CreateInstance(repositoryType, _context);
            _repositories.Add(typeof(TRepository), repositoryInstance);
            return repositoryInstance;

        }
    }
}

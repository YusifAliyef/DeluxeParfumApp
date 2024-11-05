using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Interfaces
{
    public interface IUnitOfWork
    {
        Task Commit();
        void RollBack();

        TRepository SetRepository<TRepository>();
        TRepository GetRepository<TRepository>() where TRepository : class;
        
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IAddressRepository AddressRepository { get; }
        ICardItemRepository CardItemRepository { get; }

        ICustomerRepository CustomerRepository { get; }
        //IUploadedFileRepository 

        IOrderRepository OrderRepository { get; }
        IReviewRepository ReviewRepository { get; }
        IUserRepository UserRepository { get; }
        IRoleRepository RoleRepository { get; }
        IUserRoleRepository UserRoleRepository { get; }
      
    }
}

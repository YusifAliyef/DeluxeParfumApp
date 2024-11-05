using DeluxeParfum.Application.Interfaces;
using DeluxeParfum.Domain.Entities.Products;
using DeluxeParfum.Persistance.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Persistance.EntityFramework.Repositories
{
    public class CardItemRepository : GenericRepository<CardItem>, ICardItemRepository
    {
        public CardItemRepository(DeluxeParfumContext dbcontext) : base(dbcontext)
        {
        }
    }
}

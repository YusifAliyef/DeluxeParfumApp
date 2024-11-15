﻿using DeluxeParfum.Domain.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Interfaces
{
    public interface IUserRepository:IRepository<User>
    {
        Task AddUser(User user);

        void UpdateUser(User user);

        Task<User?> GetUserWithDetail(string email);

    }
}

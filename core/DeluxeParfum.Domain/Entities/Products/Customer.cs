﻿using DeluxeParfum.Domain.Entities.Accounts;
using DeluxeParfum.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Domain.Entities.Products
{
    public class Customer:EditedBaseEntity
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Order> Orders { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int? AddressId { get; set; }
        public Address Address { get; set; }
    }
}

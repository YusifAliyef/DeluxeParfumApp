using DeluxeParfum.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Domain.Entities.Accounts
{
    public class UserDetail:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StatusId { get; set; }
       
        public bool IsConfirmPassword { get; set; }
        public int? ConfirmCode { get; set; }
        public string FullName { get => $"{FirstName} {LastName}"; }
        public DateTime? DateOfBirth { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }


    }
}

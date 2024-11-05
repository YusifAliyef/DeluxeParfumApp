using DeluxeParfum.Domain.Entities.Common;
using DeluxeParfum.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Domain.Entities.Accounts
{
    public class User:BaseEntity
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
            UploadedFiles = new HashSet<UploadedFile>();
            Reviews=new HashSet<Review>();
        }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public UserDetail? UserDetail { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<UploadedFile> UploadedFiles { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public Customer Customer { get; set; }
    }
}

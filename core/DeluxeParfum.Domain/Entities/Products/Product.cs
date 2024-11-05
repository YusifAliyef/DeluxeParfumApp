using DeluxeParfum.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Domain.Entities.Products
{
    public class Product:EditedBaseEntity
    {

        public Product()
        {
            CardItems = new HashSet<CardItem>();
            UploadedFiles=new HashSet<UploadedFile>();
            Reviews=new HashSet<Review>();
            ProductOrders = new HashSet<ProductOrder>();

        }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<UploadedFile> UploadedFiles { get; set; }
        public ICollection<CardItem> CardItems { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<ProductOrder> ProductOrders { get; set; }


    }
}

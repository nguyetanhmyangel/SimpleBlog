using System.ComponentModel.DataAnnotations.Schema;
using SimpleBlog.Domain.Contracts;

namespace SimpleBlog.Domain.Entities.Catalog
{
    public class Product : AuditEntity<int>
    {
        public string Name { get; set; }
        public string Barcode { get; set; }

        [Column(TypeName = "text")]
        public string ImageDataUrl { get; set; }

        public string Description { get; set; }
        public decimal Rate { get; set; }
        public int BrandId { get; set; }
        //public virtual Brand Brand { get; set; }
    }
}
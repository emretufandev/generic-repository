using generic_repository.Core.DataAccess.Abstract;
using generic_repository.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace generic_repository.Entity
{
    public class Product : BaseEntity, ISoftDeletable
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedTime { get; set; }

        public virtual Category Category { get; set; }
    }
}

using generic_repository.Core.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace generic_repository.Entity
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Products = new Collection<Product>();
        }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothBazar.Entities
{
    public class Category  : EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<Product> Product { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothBazar.Entities
{
    public class EntityBase
    {
        public int Id { get; set; }

        public string CreatedOn { get; set; }

        public string LastModifiedOn { get; set; }
    }
}

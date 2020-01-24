using EcommerceBackend.models.Loyalty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceBackend.models.City

{
    class ModelCity
    {
        public int CityId { get; set; }

        public int StateId { get; set; }

        public string Name { get; set; }

        public ModelState State { get; set; } 
    }
}

using EcommerceBackend.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceBackend.Models.City

{
    class ModelCity
    {
        public int CityId { get; set; }

        public int StateId { get; set; }

        public string Name { get; set; }

        public ModelState State { get; set; } 
    }
}

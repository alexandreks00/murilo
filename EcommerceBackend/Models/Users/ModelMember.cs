using EcommerceBackend.models.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceBackend.models.Loyalty
{
    class ModelMember
    {
        public string Code { get; set; }

        public string DateOfBirth { get; set; }

        public string CityId { get; set; }

        public string Phone1 { get; set; }

        public ModelCity City { get; set; }
    }
}

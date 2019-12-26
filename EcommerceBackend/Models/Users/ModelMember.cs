using DemoRestSharp.Models.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoRestSharp.Models.Users
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

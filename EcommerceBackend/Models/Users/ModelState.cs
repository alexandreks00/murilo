using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoRestSharp.Models.Users
{
    class ModelState
    {
        public int StateId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public int CountryId { get; set; }

        public ModelCountry Country { get; set; }

    }
}

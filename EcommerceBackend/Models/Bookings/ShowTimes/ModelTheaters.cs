using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceBackend.models.Bookings.ShowTimes
{
    class ModelTheaters
    {
        public string TheaterCode { get; set; }
        public string Utc { get; set; }
        public IList<ModelDate> Dates { get; set; }

    }
}


﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceBackend.models.Bookings.ShowTimes
{
    public class ModelTheaters
    {
        public string TheaterCode { get; set; }
        public string Utc { get; set; }
        public List<ModelDate> Dates { get; set; }

    }
}


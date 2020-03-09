using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceBackend.models.SuperSaver
{
    public class ModelSuperSaver
    {
        public string code { get; set; }
        public string saleChannel { get; set; }
        public string theater { get; set; }
        public string movie { get; set; }
        public string theaterRoom { get; set; }
        public string sessionType { get; set; }
        public DateTime sessionDate { get; set; }
        public string seatNumber { get; set; }
        public string seatType { get; set; }


    }
}

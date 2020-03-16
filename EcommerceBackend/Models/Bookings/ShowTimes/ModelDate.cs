using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceBackend.models.Bookings.ShowTimes
{
    class ModelDate
    {
        public DateTime Date { get; set; }
        public DateTime ExhibitionDate { get; set; }
        public IList<ModelShowTime> ShowTimes { get; set; }
    }
}

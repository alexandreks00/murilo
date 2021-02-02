using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceBackend.models.Bookings.ShowTimes
{
    public class ModelTheatersShowTimes
    {
        public List<ModelTheaters> Theaters { get; set; }
        public List<ModelDate> Dates { get; set; }
        public List<ModelShowTime> ShowTimes { get; set; }
        public List<ModelSuggestion> Suggestions { get; set; }
        public ModelTheatersShowTimes TheatersShowtime { get; set; }

    }
}

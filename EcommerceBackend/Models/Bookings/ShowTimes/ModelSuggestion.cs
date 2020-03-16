using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceBackend.models.Bookings.ShowTimes
{
    class ModelSuggestion
    {
        public int id { get; set; }
        public string ShowTimeId { get; set; }
        public DateTime ExhibitionDate { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public int Level { get; set; }
        public bool XD { get; set; }
        public bool Prime { get; set; }
        public bool DBOX { get; set; }
        public bool D3D { get; set; }
        public int aud { get; set; }
        public bool IsSessionExpired { get; set; }
    }
}

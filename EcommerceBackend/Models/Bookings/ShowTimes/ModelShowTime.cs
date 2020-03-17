using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceBackend.models.Bookings.ShowTimes
{
    class ModelShowTime
    {
        public int id { get; set; }
        public string ShowTimeId { get; set; }
        public DateTime date { get; set; }
        public int cm { get; set; }
        public string tht { get; set; }
        public string mov { get; set; }
        public int aud { get; set; }
        public int xd { get; set; }
        public int prime { get; set; }
        public int dbox { get; set; }
        public int d3d { get; set; }
        public int pre { get; set; }
        public int psl { get; set; }
        public int deb { get; set; }
        public string time { get; set; }
        public int loc { get; set; }
        public int MoviePrintCode { get; set; }
        public bool IsSessionExpired { get; set; }
        public bool TheaterAllow { get; set; }
        public string Utc { get; set; }
        public int level { get; set; }
        public IList<ModelSuggestion> Suggestions { get; set; }
        public int SnackCategoryId { get; set; }
        public string SnackCategoryIconUrl { get; set; }
    }
}

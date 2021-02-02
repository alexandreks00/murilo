using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoRestSharp.models.Theaters
{
    public class ModelAuditoriums
    {
        [JsonProperty("TheaterCode", Required = Required.Always)]
        public long TheaterCode { get; set; }

        [JsonProperty("Description", Required = Required.Always)]
        public String Description { get; set; }

        [JsonProperty("AuditoriumCode", Required = Required.Always)]
        public long AuditoriumCode { get; set; }

        [JsonProperty("TotalSeats", Required = Required.Always)]
        public long TotalSeats { get; set; }

        [JsonProperty("XD", Required = Required.Always)]
        public bool Xd { get; set; }

        [JsonProperty("Prime", Required = Required.Always)]
        public bool Prime { get; set; }

        [JsonProperty("DBOX", Required = Required.Always)]
        public bool Dbox { get; set; }

        [JsonProperty("DboxDescription", Required = Required.Always)]
        public string DboxDescription { get; set; }

        [JsonProperty("Status", Required = Required.Always)]
        public long Status { get; set; }


    }
}

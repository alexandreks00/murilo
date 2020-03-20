using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoRestSharp.models.Theaters
{
    public class ModelDetalhesCinema
    {
        public string Id { get; set; }
        public string TheaterCode { get; set; }
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Address1 { get; set; }
        public string CityId { get; set; }
        public string StateId { get; set; }
        public string Phone1 { get; set; }
        public string Status { get; set; }
        public string InvoiceEnabled { get; set; }
        public string SnackbarEnabled { get; set; }
        public string IngressoSiteCode { get; set; }
        public string CNPJ { get; set; }
        public string ZipCode { get; set; }

        public List<ModelCity> City { get; set; }
        public List<ModelState> State { get; set; }



    }
}

using Newtonsoft.Json;
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
        public string TheaterCodePrime { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public int CityId { get; set; }
        public List<ModelCity> City { get; set; }
        public string StateId { get; set; }
        public List<ModelState> State { get; set; }
        public string Phone1 { get; set; }
        public string Remarks { get; set; }
        public string PriceTableHTML { get; set; }
        public int Status { get; set; }

        [JsonProperty("Auditoriums", Required = Required.Always)]
        public List<ModelAuditoriums> Auditoriums { get; set; }

        public string InvoiceEnabled { get; set; }
        public string SnackbarEnabled { get; set; }
        public string IngressoSiteCode { get; set; }
        public string SnackbarPOSCode { get; set; }
        public string CNPJ { get; set; }
        public string ZipCode { get; set; }
        public int EconomicGroupId { get; set; }
        public object Utc { get; set; }
        public bool WebSale { get; set; }
        public bool AppSale { get; set; }
        public object IP { get; set; }
        public object Licence { get; set; }
        public object AVCB { get; set; }
        public object LicenceDate { get; set; }
        public object AVCBDate { get; set; }
        public object MerchantId { get; set; }
        public object MerchantKey { get; set; }
        public bool SendSnackPdv { get; set; }
        public bool TicketEnabled { get; set; }
        public bool LobbyEnabled { get; set; }
        public int SnackType { get; set; }
        public List<object> SnackOptions { get; set; }






    }
}

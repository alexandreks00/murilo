using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceBackend.models.Order
{
   public class ModelAppInfo
    {
        public string Fingerprint { get; set; } 
        public string deviceModel { get; set; } 
        public string devicePlatform { get; set; } 
        public string deviceUUID { get; set; } 
        public ModelGeolocation geolocation { get; set; } 
        public string version { get; set; } 


    }
}

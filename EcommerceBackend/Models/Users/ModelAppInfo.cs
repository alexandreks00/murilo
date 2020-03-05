using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceBackend.models.Users
{
    public class ModelAppInfo
    {
        public string deviceModel { get; set; }

        public string devicePlatform { get; set; }

        public string deviceUUID { get; set; }

        public string version { get; set; }
    }
}

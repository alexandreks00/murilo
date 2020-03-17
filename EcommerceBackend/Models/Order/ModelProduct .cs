using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoRestSharp.models.Order
{
    public class ModelProduct
    {
        public string name { get; set; }
        public string theaterName { get; set; }
        public string theaterAddress { get; set; }
        public string id { get; set; }
        public string unitPrice { get; set; }
        public string status { get; set; }
        public string integrationCode { get; set; }
        public string integrationTracking { get; set; }

    }
}

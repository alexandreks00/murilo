using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoRestSharp.models.Order
{
    public class ModelOrderLast
    {
        public string id { get; set; }


        public List<ModelAccount> account { get; set; }
        public List<ModelProduct> products { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoRestSharp.models.Order;

namespace EcommerceBackend.models.Order
{
    public class ModelStartOrder
    {
        public List<ModelAccount> Accounts { get; set; }
        public List<ModelAppInfo> AppInfos { get; set; }
        public List<ModelProduct> Products { get; set; }
        public List<ModelFee> Fees { get; set; }
        public int theaterId { get; set; }
        public double fee { get; set; }
        public int movieId { get; set; }
        public List<ModelPayment> payment { get; set; }
        public List<ModelProduct> products { get; set; }
        public double total { get; set; }
}
}

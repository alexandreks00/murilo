using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceBackend.models.Order
{
   public class ModelPayment { 


        public string number { get; set; }
        public string cpf { get; set; }
        public string cvc { get; set; }
        public string expiryMonth { get; set; }
        public string expiryYear { get; set; }
        public string holderName { get; set; }
        public bool saveCardInformation { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoRestSharp.models.Order
{
    public class ModelOrder
    {
        // Comum para todos
        public string total { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string id { get; set; }
        public string externalId { get; set; }
        public int status { get; set; }
        public string orderDate { get; set; }
        public string expirationDate { get; set; }
        public string theaterId { get; set; }
        public string movieId { get; set; }


        // Lists utilizadas nessa classe
        public List<ModelProduct> products { get; set; }
        public List<ModelTickets> tickets { get; set; }
        public List<ModelFee> fee { get; set; }
  
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Xunit;
using Xunit.Sdk;
using System.Web.DynamicData;
using System.Globalization;

namespace DemoRestSharp.models.Order
{
    public class ModelOrder
    {
        // Comum para todos
        [Required(ErrorMessage = "Propriedade TOTAL nao encontrada")]
        [Range(0, Double.PositiveInfinity, ErrorMessage = "Status divergente ou não mapeado")]
        public Double total { get; set; }

        [Required(ErrorMessage = "Propriedade Email nao encontrada")]
        public string Email { get; set; }
        public string Password { get; set; }

        [Required(ErrorMessage = "Propriedade id nao encontrada")]
        public string id { get; set; }
        

        [Required(ErrorMessage = "Propriedade externalId nao encontrada")]
        public string externalId { get; set; }

        [Required(ErrorMessage = "Propriedade externalId nao encontrada")]
        [Range(1, 40, ErrorMessage = "Status divergente ou não mapeado")]
        public int status { get; set; }

        [Required(ErrorMessage = "Propriedade orderDate nao encontrada")]
        public string orderDate { get; set; }

        [Required(ErrorMessage = "Propriedade expirationDate nao encontrada")]
        public string expirationDate { get; set; }

        [Required(ErrorMessage = "Propriedade theaterId nao encontrada")]
        [Range(1, int.MaxValue, ErrorMessage = "Status divergente ou não mapeado")]
        public int theaterId { get; set; }

        [Required(ErrorMessage = "Propriedade movieId nao encontrada")]
        [Range(1, int.MaxValue, ErrorMessage = "Status divergente ou não mapeado")]
        public string movieId { get; set; }


        // Lists utilizadas nessa classe
        public List<ModelProduct> products { get; set; }
        public List<ModelTickets> tickets { get; set; }
        public List<ModelFee> fee { get; set; }
  
        
    }
}

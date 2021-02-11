using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoRestSharp.models.Order
{
    public class ModelOrderLast
    {
        [Required(ErrorMessage = "Propriedade id nao encontrada")]
        public string id { get; set; }
        public List<ModelAccount> account { get; set; }
        public List<ModelProduct> products { get; set; }
    }
}

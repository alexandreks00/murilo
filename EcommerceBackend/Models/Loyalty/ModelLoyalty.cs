using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceBackend.models.Loyalt
{
    public class ModelLoyalty
    {
        public Boolean Ok { get; set; }

        public List<string> Messages { get; set; }

        public String id { get; set; }
        public String name { get; set; }
        public String buttonDescription { get; set; }
        public Double price { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string category { get; set; }
        public Double balance { get; set; }
        public string expired { get; set; }



        public List<ModelBenefits> benefits { get; set; }
        public List<ModelMenus> menus { get; set; }

        

    }




}
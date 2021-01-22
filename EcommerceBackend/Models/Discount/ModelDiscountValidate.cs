using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EcommerceBackend.models.Discount
{
   public class ModelDiscountValidate
    {
        [JsonPropertyName("isCodeValid")]
        public bool IsCodeValid { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("theaterId")]
        public int TheaterId { get; set; }

        [JsonPropertyName("ruleType")]
        public int RuleType { get; set; }

        [JsonPropertyName("enabledTypes")]
        public IList<int> EnabledTypes { get; set; }

        [JsonPropertyName("validUntil")]
        public DateTime ValidUntil { get; set; }
    }
}

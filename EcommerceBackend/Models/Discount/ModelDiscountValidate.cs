using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EcommerceBackend.models.Discount
{
   public class ModelDiscountValidate
    {
        [JsonProperty("isCodeValid", Required = Required.Always)]
        public bool IsCodeValid { get; set; }

        [JsonProperty("message", Required = Required.Always)]
        public string Message { get; set; }

        [JsonProperty("description", Required = Required.Always)]
        public string Description { get; set; }

        [JsonProperty("theaterId", Required = Required.Always)]
        public long TheaterId { get; set; }

        [JsonProperty("ruleType", Required = Required.Always)]
        public int RuleType { get; set; }

        [JsonProperty("enabledTypes", Required = Required.Always)]
        public IList<int> enabledTypes { get; set; }

        [JsonProperty("validUntil", Required = Required.Always)]
        public DateTimeOffset ValidUntil { get; set; }
    }
}

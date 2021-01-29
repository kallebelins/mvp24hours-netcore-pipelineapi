using Mvp24Hours.Core.ValueObjects;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace PipelineAPI.Core.ValueObjects
{
    public class Product : BaseVO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }

        [JsonProperty("image_link")]
        public string ImageLink { get; set; }

        [JsonProperty("product_type")]
        public string ProductType { get; set; }

        public string Category { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }

}

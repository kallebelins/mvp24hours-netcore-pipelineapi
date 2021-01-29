using Mvp24Hours.Core.ValueObjects;
using System.Collections.Generic;

namespace PipelineAPI.Core.ValueObjects.Filters
{
    public class ProductFilter : BaseVO
    {
        public string Category { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Category;
        }
    }
}

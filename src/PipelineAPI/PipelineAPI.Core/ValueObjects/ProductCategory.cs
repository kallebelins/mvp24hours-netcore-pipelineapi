using Mvp24Hours.Core.ValueObjects;
using System.Collections.Generic;

namespace PipelineAPI.Core.ValueObjects
{
    public class ProductCategory : BaseVO
    {
        public string Name { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
    }

}

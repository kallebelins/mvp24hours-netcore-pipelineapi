using Mvp24Hours.Core.Contract.Infrastructure.Pipe;
using Mvp24Hours.Infrastructure.Pipe.Operations;
using PipelineAPI.Core.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PipelineAPI.ApplicationWebClient.Operations.ProductCategoryList
{
    internal class ProductCategoryResponseMapperOperation : OperationMapperAsync<IEnumerable<ProductCategory>>
    {
        public override async Task<IEnumerable<ProductCategory>> MapperAsync(IPipelineMessage input)
        {
            var products = input?.GetContent<IEnumerable<Product>>();

            if (products == null)
            {
                NotificationContext.AddNotification("ProductCategoryResponseMapperOperation", "Product not found.");
                return null;
            }

            var result = new List<ProductCategory>();
            foreach (var item in products)
            {
                if (!string.IsNullOrEmpty(item.Category)
                    && !result.Any(x => x.Name == item.Category))
                {
                    result.Add(new ProductCategory()
                    {
                        Name = item.Category
                    });
                }
            }
            return await Task.FromResult(result);
        }
    }
}

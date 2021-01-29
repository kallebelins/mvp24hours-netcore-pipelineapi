using Mvp24Hours.Core.Contract.Infrastructure.Pipe;
using Mvp24Hours.Infrastructure.Pipe.Operations;
using PipelineAPI.Core.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PipelineAPI.ApplicationFile.Operations.ProductCategoryList
{
    internal class ProductCategoryResponseMapperOperation : OperationMapperAsync<IEnumerable<ProductCategory>>
    {
        public override Task<IPipelineMessage> Execute(IPipelineMessage input)
        {
            var result = input?.GetContent<IEnumerable<Product>>();

            if (result == null)
            {
                Context.AddNotification("ProductCategoryResponseMapperOperation", "Product not found.");
            }
            else
            {
                input.AddContent(Mapper(result));
            }

            return Task.FromResult(input);
        }

        public override IEnumerable<ProductCategory> Mapper(params object[] data)
        {
            var products = data.ElementAtOrDefault(0) as IEnumerable<Product>;
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
            return result;
        }
    }
}

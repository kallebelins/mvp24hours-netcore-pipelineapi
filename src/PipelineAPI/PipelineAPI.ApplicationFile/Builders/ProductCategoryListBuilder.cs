using Mvp24Hours.Core.Contract.Infrastructure.Pipe;
using PipelineAPI.ApplicationFile.Operations.ProductCategoryList;
using PipelineAPI.Core.Contract.Pipelines.ProductCategories;

namespace PipelineAPI.ApplicationFile.Factories
{
    public class ProductCategoryListBuilder : IProductCategoryListBuilder
    {
        public IPipelineAsync Builder(IPipelineAsync pipeline)
        {
            return pipeline
                //.AddAsync(new ProductCategoryRequestMapperOperation())
                .AddAsync(new ProductCategoryFileOperation())
                .AddAsync(new ProductCategoryResponseMapperOperation());
        }
    }
}

using Mvp24Hours.Core.Contract.Infrastructure.Pipe;
using PipelineAPI.ApplicationWebClient.Operations.ProductCategoryList;
using PipelineAPI.Core.Contract.Pipelines.ProductCategories;

namespace PipelineAPI.ApplicationWebClient.Factories
{
    public class ProductCategoryListBuilder : IProductCategoryListBuilder
    {
        public IPipelineAsync Builder(IPipelineAsync pipeline)
        {
            return pipeline
                //.AddAsync(new ProductCategoryRequestMapperOperation())
                .AddAsync(new ProductCategoryWebClientOperation())
                .AddAsync(new ProductCategoryResponseMapperOperation());
        }
    }
}

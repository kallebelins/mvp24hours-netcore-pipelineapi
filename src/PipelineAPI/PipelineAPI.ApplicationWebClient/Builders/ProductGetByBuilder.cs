using Mvp24Hours.Core.Contract.Infrastructure.Pipe;
using PipelineAPI.ApplicationWebClient.Operations.ProductGetBy;
using PipelineAPI.Core.Contract.Pipelines.Products;

namespace PipelineAPI.ApplicationWebClient.Factories
{
    public class ProductGetByBuilder : IProductGetByBuilder
    {
        public IPipelineAsync Builder(IPipelineAsync pipeline)
        {
            return pipeline
                .AddAsync(new ProductRequestMapperOperation())
                .AddAsync(new ProductWebClientOperation())
                .AddAsync(new ProductResponseMapperOperation());
        }
    }
}

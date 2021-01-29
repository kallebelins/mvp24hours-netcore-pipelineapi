using Mvp24Hours.Core.Contract.Infrastructure.Pipe;
using PipelineAPI.ApplicationFile.Operations.ProductGetBy;
using PipelineAPI.Core.Contract.Pipelines.Products;

namespace PipelineAPI.ApplicationFile.Factories
{
    public class ProductGetByBuilder : IProductGetByBuilder
    {
        public IPipelineAsync Builder(IPipelineAsync pipeline)
        {
            return pipeline
                .AddAsync(new ProductRequestMapperOperation())
                .AddAsync(new ProductFileOperation())
                .AddAsync(new ProductResponseMapperOperation());
        }
    }
}

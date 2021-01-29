using Mvp24Hours.Core.Contract.Infrastructure.Pipe;
using Mvp24Hours.Core.Contract.Logic;
using Mvp24Hours.Infrastructure.Extensions;
using Mvp24Hours.Infrastructure.Helpers;
using Mvp24Hours.Infrastructure.Pipe;
using Mvp24Hours.Infrastructure.Pipe.Operations.Files;
using PipelineAPI.Core.Contract.Logic;
using PipelineAPI.Core.Contract.Pipelines.Products;
using PipelineAPI.Core.ValueObjects;
using PipelineAPI.Core.ValueObjects.Filters;
using System.Threading.Tasks;

namespace PipelineAPI.Application.Logic
{
    public partial class ProductService : IProductService
    {
        public async Task<IBusinessResult<Product>> GetBy(ProductFilter filter)
        {
            IPipelineAsync pipeline = new PipelineAsync();
            pipeline.AddAsync(new FileLogWriteOperation());

            var builder = HttpContextHelper.GetService<IProductGetByBuilder>();
            builder.Builder(pipeline);

            pipeline.AddAsync(new FileLogWriteOperation());

            var result = await pipeline.Execute(filter.ToMessage());

            return result.ToBusiness<Product>();
        }
    }
}

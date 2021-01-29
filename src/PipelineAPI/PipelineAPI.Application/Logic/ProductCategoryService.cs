using Mvp24Hours.Core.Contract.Infrastructure.Pipe;
using Mvp24Hours.Core.Contract.Logic;
using Mvp24Hours.Infrastructure.Extensions;
using Mvp24Hours.Infrastructure.Helpers;
using Mvp24Hours.Infrastructure.Pipe;
using Mvp24Hours.Infrastructure.Pipe.Operations.Files;
using PipelineAPI.Core.Contract.Logic;
using PipelineAPI.Core.Contract.Pipelines.ProductCategories;
using PipelineAPI.Core.ValueObjects;
using System.Threading.Tasks;

namespace PipelineAPI.Application.Logic
{
    public partial class ProductCategoryService : IProductCategoryService
    {
        public async Task<IBusinessResult<ProductCategory>> List()
        {
            IPipelineAsync pipeline = new PipelineAsync();
            pipeline.AddAsync(new FileLogWriteOperation());

            var builder = HttpContextHelper.GetService<IProductCategoryListBuilder>();
            builder.Builder(pipeline);

            pipeline.AddAsync(new FileLogWriteOperation());

            var result = await pipeline.Execute(new PipelineMessage());

            return result.ToBusiness<ProductCategory>();
        }
    }
}

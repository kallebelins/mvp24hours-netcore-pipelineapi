using Mvp24Hours.Core.Contract.Logic;
using PipelineAPI.Core.ValueObjects;
using PipelineAPI.Core.ValueObjects.Filters;
using System.Threading.Tasks;

namespace PipelineAPI.Core.Contract.Logic
{
    public interface IProductService
    {
        Task<IBusinessResult<Product>> GetBy(ProductFilter filter);
    }
}

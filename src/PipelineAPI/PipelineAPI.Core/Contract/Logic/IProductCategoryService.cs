using Mvp24Hours.Core.Contract.Logic;
using PipelineAPI.Core.ValueObjects;
using System.Threading.Tasks;

namespace PipelineAPI.Core.Contract.Logic
{
    public interface IProductCategoryService
    {
        Task<IBusinessResult<ProductCategory>> List();
    }
}

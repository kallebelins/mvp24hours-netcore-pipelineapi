using Microsoft.AspNetCore.Mvc;
using Mvp24Hours.Core.Contract.Logic;
using Mvp24Hours.WebAPI.Extensions;
using PipelineAPI.Application;
using PipelineAPI.Core.ValueObjects;
using System.Threading.Tasks;

namespace PipelineAPI.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        [Route("", Name = "ProductCategoryGet")]
        public async Task<IBusinessResult<ProductCategory>> Get()
        {
            var result = await FacadeService.ProductCategoryService.List();

            #region [ hateaos ]
            result.AddLinkSelf("ProductCategoryGet");
            #endregion

            return result;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Mvp24Hours.Core.Contract.Logic;
using Mvp24Hours.WebAPI.Extensions;
using PipelineAPI.Application;
using PipelineAPI.Core.ValueObjects;
using PipelineAPI.Core.ValueObjects.Filters;
using System.Threading.Tasks;

namespace PipelineAPI.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        [Route("", Name = "ProductGet")]
        public async Task<IBusinessResult<Product>> Get([FromQuery] ProductFilter filter)
        {
            var result = await FacadeService.ProductService.GetBy(filter);

            #region [ hateaos ]
            result.AddLinkSelf("ProductGet");
            #endregion

            return result;

        }
    }
}

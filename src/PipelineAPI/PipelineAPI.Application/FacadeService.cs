using Mvp24Hours.Infrastructure.Helpers;
using PipelineAPI.Core.Contract.Logic;

namespace PipelineAPI.Application
{
    /// <summary>
    /// 
    /// </summary>
    public class FacadeService
    {
        #region [ Services ]
        public static IProductService ProductService
        {
            get { return HttpContextHelper.GetService<IProductService>(); }
        }
        public static IProductCategoryService ProductCategoryService
        {
            get { return HttpContextHelper.GetService<IProductCategoryService>(); }
        }
        #endregion
    }
}

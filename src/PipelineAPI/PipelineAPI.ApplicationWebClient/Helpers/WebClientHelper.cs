using Mvp24Hours.Infrastructure.Helpers;

namespace PipelineAPI.ApplicationWebClient.Helpers
{
    internal class WebClientHelper
    {
        readonly static string SERVICE_URL = ConfigurationHelper.GetSettings("WebClient:ServiceUrl");
        public readonly static string ProductCacheKey = "products_webclient";

        public static string GetUrl()
        {
            return SERVICE_URL;
        }
    }
}

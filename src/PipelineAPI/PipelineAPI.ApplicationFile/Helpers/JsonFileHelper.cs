using Mvp24Hours.Infrastructure.Helpers;
using System.IO;

namespace PipelineAPI.ApplicationFile.Helpers
{
    internal class JsonFileHelper
    {
        readonly static string FILENAME = "products.json";
        public readonly static string ProductCacheKey = "products_jsonfile";

        public static string GetPath()
        {
            return $"{Directory.GetCurrentDirectory()}\\Resources\\{FILENAME}";
        }
    }
}

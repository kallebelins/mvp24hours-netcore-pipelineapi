using Microsoft.Extensions.Caching.Memory;
using Mvp24Hours.Core.Contract.Infrastructure.Pipe;
using Mvp24Hours.Infrastructure.Helpers;
using Mvp24Hours.Infrastructure.Pipe.Operations;
using Newtonsoft.Json;
using PipelineAPI.ApplicationFile.Helpers;
using PipelineAPI.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace PipelineAPI.ApplicationFile.Operations.ProductCategoryList
{
    internal class ProductCategoryFileOperation : OperationBaseAsync
    {
        private readonly IMemoryCache _cache;

        public ProductCategoryFileOperation()
            : base()
        {
            _cache = HttpContextHelper.GetService<IMemoryCache>();
        }

        public async override Task<IPipelineMessage> Execute(IPipelineMessage input)
        {
            IEnumerable<Product> products;

            if (!_cache.TryGetValue(JsonFileHelper.ProductCacheKey, out products))
            {
                var response = await File.ReadAllTextAsync(JsonFileHelper.GetPath());
                products = JsonConvert.DeserializeObject<IEnumerable<Product>>(response);

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(24));

                // Save data in cache.
                _cache.Set(JsonFileHelper.ProductCacheKey, products, cacheEntryOptions);
            }

            if (products != null)
            {
                input.AddContent(products);
            }

            return input;
        }
    }
}

using Microsoft.Extensions.Caching.Memory;
using Mvp24Hours.Core.Contract.Infrastructure.Pipe;
using Mvp24Hours.Infrastructure.Helpers;
using Mvp24Hours.Infrastructure.Pipe.Operations;
using Newtonsoft.Json;
using PipelineAPI.ApplicationWebClient.Helpers;
using PipelineAPI.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PipelineAPI.ApplicationWebClient.Operations.ProductCategoryList
{
    internal class ProductCategoryWebClientOperation : OperationBaseAsync
    {
        private readonly IMemoryCache _cache;

        public ProductCategoryWebClientOperation()
            : base()
        {
            _cache = HttpContextHelper.GetService<IMemoryCache>();
        }

        public async override Task<IPipelineMessage> Execute(IPipelineMessage input)
        {
            IEnumerable<Product> products;

            if (!_cache.TryGetValue(WebClientHelper.ProductCacheKey, out products))
            {
                var response = await WebRequestHelper.GetAsync($"{WebClientHelper.GetUrl()}");
                products = JsonConvert.DeserializeObject<IEnumerable<Product>>(response);

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(24));

                // Save data in cache.
                _cache.Set(WebClientHelper.ProductCacheKey, products, cacheEntryOptions);
            }

            if (products != null)
            {
                input.AddContent(products);
            }

            return input;
        }
    }
}

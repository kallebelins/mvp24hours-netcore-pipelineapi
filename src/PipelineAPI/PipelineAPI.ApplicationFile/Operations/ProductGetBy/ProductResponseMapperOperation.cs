﻿using Mvp24Hours.Core.Contract.Infrastructure.Pipe;
using Mvp24Hours.Infrastructure.Pipe.Operations;
using PipelineAPI.Core.ValueObjects;
using System;
using System.Threading.Tasks;

namespace PipelineAPI.ApplicationFile.Operations.ProductGetBy
{
    internal class ProductResponseMapperOperation : OperationMapperAsync<Product>
    {
        public override Task<Product> MapperAsync(IPipelineMessage input)
        {
            throw new NotImplementedException();
        }
    }
}

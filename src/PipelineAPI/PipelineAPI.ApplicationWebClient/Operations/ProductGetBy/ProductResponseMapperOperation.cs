﻿using Mvp24Hours.Core.Contract.Infrastructure.Pipe;
using Mvp24Hours.Infrastructure.Pipe.Operations;
using PipelineAPI.Core.ValueObjects;
using System;
using System.Threading.Tasks;

namespace PipelineAPI.ApplicationWebClient.Operations.ProductGetBy
{
    internal class ProductResponseMapperOperation : OperationMapperAsync<Product>
    {
        public override Task<IPipelineMessage> Execute(IPipelineMessage input)
        {
            throw new NotImplementedException();
        }

        public override Product Mapper(params object[] data)
        {
            throw new NotImplementedException();
        }
    }
}

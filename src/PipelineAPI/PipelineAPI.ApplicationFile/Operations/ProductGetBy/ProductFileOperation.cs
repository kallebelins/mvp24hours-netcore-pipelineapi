using Mvp24Hours.Core.Contract.Infrastructure.Pipe;
using Mvp24Hours.Infrastructure.Pipe.Operations;
using PipelineAPI.ApplicationFile.Helpers;
using PipelineAPI.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PipelineAPI.ApplicationFile.Operations.ProductGetBy
{
    internal class ProductFileOperation : OperationBaseAsync
    {
        public override Task<IPipelineMessage> Execute(IPipelineMessage input)
        {
            throw new NotImplementedException();
        }
    }
}

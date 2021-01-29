using Mvp24Hours.Core.Contract.Infrastructure.Pipe;
using Mvp24Hours.Infrastructure.Pipe.Operations;
using System;
using System.Threading.Tasks;

namespace PipelineAPI.ApplicationWebClient.Operations.ProductGetBy
{
    internal class ProductWebClientOperation : OperationBaseAsync
    {
        public override Task<IPipelineMessage> Execute(IPipelineMessage input)
        {
            throw new NotImplementedException();
        }
    }
}

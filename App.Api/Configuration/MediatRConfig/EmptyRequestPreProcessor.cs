using MediatR.Pipeline;

namespace App.Api.Configuration.MediatRConfig
{
    public class EmptyRequestPreProcessor<TRequest> : IRequestPreProcessor<TRequest>
    {
        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
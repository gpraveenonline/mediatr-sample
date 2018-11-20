using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR.Queries
{
    public class ResponseQuery
    {
        public long Id { get; set; }

        public string Description { get; set; }
    }
    public class RequestQuery : IRequest<ResponseQuery>
    {
        public long Id { get; set; }
    }
    public class QueryHandler : IRequestHandler<RequestQuery, ResponseQuery>
    {
        public Task<ResponseQuery> Handle(RequestQuery request, CancellationToken cancellationToken)
        {
            Trace.WriteLine("QueryHandler.Handle(RequestQuery)");

            return Task.FromResult(new ResponseQuery { Id = request.Id, Description = $"Description {request.Id}" });
        }
    }
}

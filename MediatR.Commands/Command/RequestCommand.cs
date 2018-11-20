using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR.Commands
{
    public class RequestCommand : IRequest
    {
        public long Id { get; set; }

        public string Description { get; set; }
    }

    public class RequestCommandHandler : AsyncRequestHandler<RequestCommand>
	{
		protected override Task Handle(RequestCommand request, CancellationToken cancellationToken)
		{
			return Task.Run(() => Trace.WriteLine("RequestCommandHandler.Handle(RequestCommand)"));
		}
	}
}

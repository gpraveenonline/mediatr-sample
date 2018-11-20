using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR.Notifications
{
    public class Notification : INotification
    {
        public long Id { get; set; }
    }

    public class NotificationHandler1 : INotificationHandler<Notification>
	{
		public Task Handle(Notification notification, CancellationToken cancellationToken)
		{
			return Task.Run(() => Trace.WriteLine("NotificationHandler1.Handle(Notification)"));
		}
	}
    public class NotificationHandler2 : INotificationHandler<Notification>
    {
        public Task Handle(Notification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() => Trace.WriteLine("NotificationHandler2.Handle(Notification)"));
        }
    }
}

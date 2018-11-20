using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using MediatR.Commands;
using MediatR.Notifications;
using MediatR.Queries;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediatR.Tests
{
	[TestClass]
	public class Tests
	{
		private readonly IMediator _mediator;

		public Tests()
		{
			var services = new ServiceCollection();
			services.AddMediatR(Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(Assembly.Load));
			_mediator = services.BuildServiceProvider().GetService<IMediator>();
		}

        [TestMethod]
        //Command Request
        //mediatR.Send
        public void CommandAsync()
        {
            _mediator.Send(new RequestCommand { Id = 1, Description = "Description 1" });
        }

        [TestMethod]
        //Query Request + Response
        //mediatR.Send
		public void QueryAsync()
		{
			var result = _mediator.Send(new RequestQuery { Id = 1 });
			Assert.IsTrue(result.Result.Id == 1);
		}

		[TestMethod]
        //Publish a Notification
        //mediatR.Publish
		public void Publish()
		{
			_mediator.Publish(new Notification());
		}
	}
}

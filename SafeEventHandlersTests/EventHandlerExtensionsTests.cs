using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Threading;
namespace Tests
{
    [TestFixture()]
    public class EventHandlerExtensionsTests
    {
        private class TestEventArgs : EventArgs
        {

        }

        private event EventHandler handler;
        private event EventHandler<TestEventArgs> genericHandler;

        [TearDown]
        public void TearDown()
        {
            if (handler != null)
            {
                foreach (var invocation in handler.GetInvocationList())
                {
                    handler -= (EventHandler)invocation;
                }
            }
            if (genericHandler != null)
            {
                foreach (var invocation in genericHandler.GetInvocationList())
                {
                    genericHandler -= (EventHandler<TestEventArgs>)invocation;
                }
            }
        }

        [Test()]
        public void Fire_Test()
        {
            var expectedArgs = EventArgs.Empty;

            var eventFired = false;

            EventHandler action = (o, e) =>
            {
                Assert.That(o, Is.SameAs(this));
                Assert.That(e, Is.EqualTo(expectedArgs));

                eventFired = true;
            };

            handler += action;

            handler.Fire(this, expectedArgs);

            Assert.That(eventFired);
        }

        [Test()]
        public void Fire_TestGenericHandler()
        {
            var expectedArgs = new TestEventArgs();

            var eventFired = false;

            EventHandler<TestEventArgs> action = (o, e) =>
            {
                Assert.That(o, Is.SameAs(this));
                Assert.That(e, Is.EqualTo(expectedArgs));

                eventFired = true;
            };

            genericHandler += action;

            genericHandler.Fire(this, expectedArgs);

            Assert.That(eventFired);
        }
    }
}

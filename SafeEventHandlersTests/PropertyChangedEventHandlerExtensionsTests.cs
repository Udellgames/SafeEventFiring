using NUnit.Framework;
using System;
using System.ComponentModel;

namespace Tests
{
    [TestFixture]
    public class PropertyChangedEventHandlerExtensionsTests
    {

        private event PropertyChangedEventHandler handler;

        [Test]
        public void Fire_Test()
        {
            var expectedArgs = new PropertyChangedEventArgs("foo");

            var eventFired = false;

            PropertyChangedEventHandler action = (o, e) =>
            {
                Assert.That(o, Is.SameAs(this));
                Assert.That(e, Is.EqualTo(expectedArgs));

                eventFired = true;
            };

            handler += action;

            handler.Fire(this, expectedArgs);

            Assert.That(eventFired);
        }

        [TearDown]
        public void TearDown()
        {
            if (handler != null)
            {
                foreach (var invocation in handler.GetInvocationList())
                {
                    handler -= (PropertyChangedEventHandler)invocation;
                }
            }
        }
    }
}
// <copyright file="EventHttpAdapterTest.cs">Copyright ©  2018</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;
using Objects.Events;

namespace Tests
{
    /// <summary>This class contains parameterized unit tests for EventHttpAdapter</summary>
    [TestFixture]
    [PexClass(typeof(EventHttpAdapter))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class EventHttpAdapterTest
    {

        /// <summary>Test stub for .ctor()</summary>
        [PexMethod]
        public EventHttpAdapter ConstructorTest()
        {
            EventHttpAdapter target = new EventHttpAdapter();
            return target;
            // TODO: add assertions to method EventHttpAdapterTest.ConstructorTest()
        }

        /// <summary>Test stub for GetHttpAdapter()</summary>
        [PexMethod]
        public EventHttpAdapter GetHttpAdapterTest()
        {
            EventHttpAdapter result = EventHttpAdapter.GetHttpAdapter();
            return result;
            // TODO: add assertions to method EventHttpAdapterTest.GetHttpAdapterTest()
        }

        /// <summary>Test stub for LatestEvent(Guid)</summary>
        [PexMethod]
        public Event LatestEventTest([PexAssumeUnderTest]EventHttpAdapter target, Guid userGuid)
        {
            Event result = target.LatestEvent(userGuid);
            return result;
            // TODO: add assertions to method EventHttpAdapterTest.LatestEventTest(EventHttpAdapter, Guid)
        }

        /// <summary>Test stub for NotifyClient(Guid, Event)</summary>
        [PexMethod]
        public void NotifyClientTest(
            [PexAssumeUnderTest]EventHttpAdapter target,
            Guid userGuid,
            Event ev
        )
        {
            target.NotifyClient(userGuid, ev);
            // TODO: add assertions to method EventHttpAdapterTest.NotifyClientTest(EventHttpAdapter, Guid, Event)
        }

        /// <summary>Test stub for Subscribe(Guid)</summary>
        [PexMethod]
        public void SubscribeTest([PexAssumeUnderTest]EventHttpAdapter target, Guid userGuid)
        {
            target.Subscribe(userGuid);
            // TODO: add assertions to method EventHttpAdapterTest.SubscribeTest(EventHttpAdapter, Guid)
        }

        /// <summary>Test stub for Unsubscribe(Guid)</summary>
        [PexMethod]
        public void UnsubscribeTest([PexAssumeUnderTest]EventHttpAdapter target, Guid userGuid)
        {
            target.Unsubscribe(userGuid);
            // TODO: add assertions to method EventHttpAdapterTest.UnsubscribeTest(EventHttpAdapter, Guid)
        }
    }
}

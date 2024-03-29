// <copyright file="MatchFoundEventTest.cs">Copyright ©  2018</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;
using Objects.Events;

namespace Tests
{
    /// <summary>This class contains parameterized unit tests for MatchFoundEvent</summary>
    [TestFixture]
    [PexClass(typeof(MatchFoundEvent))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class MatchFoundEventTest
    {

        /// <summary>Test stub for .ctor()</summary>
        [PexMethod]
        public MatchFoundEvent ConstructorTest()
        {
            MatchFoundEvent target = new MatchFoundEvent();
            return target;
            // TODO: add assertions to method MatchFoundEventTest.ConstructorTest()
        }
    }
}

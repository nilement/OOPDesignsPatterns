// <copyright file="NullEventTest.cs">Copyright ©  2018</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;
using Objects.Events;

namespace Tests
{
    /// <summary>This class contains parameterized unit tests for NullEvent</summary>
    [TestFixture]
    [PexClass(typeof(NullEvent))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class NullEventTest
    {

        /// <summary>Test stub for .ctor()</summary>
        [PexMethod]
        public NullEvent ConstructorTest()
        {
            NullEvent target = new NullEvent();
            return target;
            // TODO: add assertions to method NullEventTest.ConstructorTest()
        }
    }
}

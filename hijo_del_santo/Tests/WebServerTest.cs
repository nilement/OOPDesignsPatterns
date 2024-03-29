// <copyright file="WebServerTest.cs">Copyright ©  2018</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;
using Server;

namespace Tests
{
    /// <summary>This class contains parameterized unit tests for WebServer</summary>
    [TestFixture]
    [PexClass(typeof(WebServer))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class WebServerTest
    {

        /// <summary>Test stub for .ctor()</summary>
        [PexMethod]
        public WebServer ConstructorTest()
        {
            WebServer target = new WebServer();
            return target;
            // TODO: add assertions to method WebServerTest.ConstructorTest()
        }

        /// <summary>Test stub for Run()</summary>
        [PexMethod]
        public void RunTest([PexAssumeUnderTest]WebServer target)
        {
            target.Run();
            // TODO: add assertions to method WebServerTest.RunTest(WebServer)
        }

        /// <summary>Test stub for Stop()</summary>
        [PexMethod]
        public void StopTest([PexAssumeUnderTest]WebServer target)
        {
            target.Stop();
            // TODO: add assertions to method WebServerTest.StopTest(WebServer)
        }
    }
}

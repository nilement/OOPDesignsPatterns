// <copyright file="MatchmakerTest.cs">Copyright ©  2018</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;
using Objects;

namespace Server.Tests
{
    /// <summary>This class contains parameterized unit tests for Matchmaker</summary>
    [PexClass(typeof(Matchmaker))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestFixture]
    public partial class MatchmakerTest
    {
        /// <summary>Test stub for AcceptPlayer(Guid)</summary>
        [PexMethod]
        public Guid AcceptPlayerTest([PexAssumeUnderTest]Matchmaker target, Guid sessionId)
        {
            Guid result = target.AcceptPlayer(sessionId);
            return result;
            // TODO: add assertions to method MatchmakerTest.AcceptPlayerTest(Matchmaker, Guid)
        }
    }
}

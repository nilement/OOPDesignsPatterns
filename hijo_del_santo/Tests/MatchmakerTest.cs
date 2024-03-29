using System.Collections.Generic;
// <copyright file="MatchmakerTest.cs">Copyright ©  2018</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;
using Objects;

namespace Objects.Tests
{
    [TestFixture]
    [PexClass(typeof(Matchmaker))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class MatchmakerTest
    {

        [PexMethod]
        public Matchmaker Constructor()
        {
            Matchmaker target = new Matchmaker();
            return target;
            // TODO: add assertions to method MatchmakerTest.Constructor()
        }

        [PexMethod]
        [PexAllowedException(typeof(KeyNotFoundException))]
        public Guid AcceptPlayer([PexAssumeUnderTest]Matchmaker target, Guid sessionId)
        {
            Guid result = target.AcceptPlayer(sessionId);
            return result;
            // TODO: add assertions to method MatchmakerTest.AcceptPlayer(Matchmaker, Guid)
        }

        [PexMethod]
        public Opponent GenerateOpponent([PexAssumeUnderTest]Matchmaker target)
        {
            Opponent result = target.GenerateOpponent();
            return result;
            // TODO: add assertions to method MatchmakerTest.GenerateOpponent(Matchmaker)
        }
    }
}

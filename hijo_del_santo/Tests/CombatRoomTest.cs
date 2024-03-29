// <copyright file="CombatRoomTest.cs">Copyright ©  2018</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;
using Objects;

namespace Tests
{
    /// <summary>This class contains parameterized unit tests for CombatRoom</summary>
    [TestFixture]
    [PexClass(typeof(CombatRoom))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class CombatRoomTest
    {

        /// <summary>Test stub for .ctor()</summary>
        [PexMethod]
        public CombatRoom ConstructorTest()
        {
            CombatRoom target = new CombatRoom();
            return target;
            // TODO: add assertions to method CombatRoomTest.ConstructorTest()
        }

        /// <summary>Test stub for AddPlayer(Guid)</summary>
        [PexMethod]
        public Guid AddPlayerTest([PexAssumeUnderTest]CombatRoom target, Guid sessionGuid)
        {
            Guid result = target.AddPlayer(sessionGuid);
            return result;
            // TODO: add assertions to method CombatRoomTest.AddPlayerTest(CombatRoom, Guid)
        }

        /// <summary>Test stub for IsWaitingForPlayer()</summary>
        [PexMethod]
        public bool IsWaitingForPlayerTest([PexAssumeUnderTest]CombatRoom target)
        {
            bool result = target.IsWaitingForPlayer();
            return result;
            // TODO: add assertions to method CombatRoomTest.IsWaitingForPlayerTest(CombatRoom)
        }
    }
}

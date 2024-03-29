// <copyright file="CombatEventTest.cs">Copyright ©  2018</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;
using Objects.Events;

namespace Tests
{
    /// <summary>This class contains parameterized unit tests for CombatEvent</summary>
    [TestFixture]
    [PexClass(typeof(CombatEvent))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class CombatEventTest
    {

        /// <summary>Test stub for .ctor()</summary>
        [PexMethod]
        public CombatEvent ConstructorTest()
        {
            CombatEvent target = new CombatEvent();
            return target;
            // TODO: add assertions to method CombatEventTest.ConstructorTest()
        }
    }
}

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;
using Objects;
using Objects.PveDecorator;
using Objects.PveOpponent.PveDecorator;

// <copyright file="SummonnerOpponentTest.cs">Copyright ©  2018</copyright>

namespace Tests
{
    /// <summary>This class contains parameterized unit tests for SummonnerOpponent</summary>
    [TestFixture]
    [PexClass(typeof(SummonnerOpponent))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class SummonnerOpponentTest
    {

        /// <summary>Test stub for .ctor(Opponent)</summary>
        [PexMethod]
        public SummonnerOpponent ConstructorTest(Opponent opponent)
        {
            SummonnerOpponent target = new SummonnerOpponent(opponent);
            return target;
            // TODO: add assertions to method SummonnerOpponentTest.ConstructorTest(Opponent)
        }

        /// <summary>Test stub for Attack()</summary>
        [PexMethod]
        public void AttackTest([PexAssumeUnderTest]SummonnerOpponent target)
        {
            target.Attack();
            // TODO: add assertions to method SummonnerOpponentTest.AttackTest(SummonnerOpponent)
        }
    }
}

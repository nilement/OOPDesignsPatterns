// <copyright file="KnightTest.cs">Copyright ©  2018</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;
using Objects.PveDecorator;

namespace Tests
{
    /// <summary>This class contains parameterized unit tests for Knight</summary>
    [TestFixture]
    [PexClass(typeof(Knight))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class KnightTest
    {

        /// <summary>Test stub for Attack()</summary>
        [PexMethod]
        public void AttackTest([PexAssumeUnderTest]Knight target)
        {
            target.Attack();
            // TODO: add assertions to method KnightTest.AttackTest(Knight)
        }

        [PexMethod]
        public void Attack([PexAssumeUnderTest]Knight target)
        {
            target.Attack();
            // TODO: add assertions to method KnightTest.Attack(Knight)
        }
    }
}

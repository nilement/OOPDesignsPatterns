// <copyright file="ModifierTest.cs">Copyright ©  2018</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;
using Objects.Items;

namespace Tests
{
    /// <summary>This class contains parameterized unit tests for Modifier</summary>
    [TestFixture]
    [PexClass(typeof(Modifier))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class ModifierTest
    {

        /// <summary>Test stub for .ctor()</summary>
        [PexMethod]
        public Modifier ConstructorTest()
        {
            Modifier target = new Modifier();
            return target;
            // TODO: add assertions to method ModifierTest.ConstructorTest()
        }

        /// <summary>Test stub for .ctor(Int32)</summary>
        [PexMethod]
        public Modifier ConstructorTest01(int modifierId)
        {
            Modifier target = new Modifier(modifierId);
            return target;
            // TODO: add assertions to method ModifierTest.ConstructorTest01(Int32)
        }
    }
}

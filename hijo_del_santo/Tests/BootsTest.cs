using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;
using Objects;
using Objects.Items;
// <copyright file="BootsTest.cs">Copyright ©  2018</copyright>

namespace Tests
{
    /// <summary>This class contains parameterized unit tests for Boots</summary>
    [TestFixture]
    [PexClass(typeof(Boots))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class BootsTest
    {

        /// <summary>Test stub for .ctor()</summary>
        [PexMethod]
        internal Boots ConstructorTest()
        {
            Boots target = new Boots();
            return target;
            // TODO: add assertions to method BootsTest.ConstructorTest()
        }

        /// <summary>Test stub for .ctor(String, Guid, Double, Int32, String, Modifier, ItemCategory, Int32, Boolean)</summary>
        [PexMethod]
        internal Boots ConstructorTest01(
            string name,
            Guid id,
            double durability,
            int buyPrice,
            string imageName,
            Modifier modifier,
            ItemCategory category,
            int power,
            bool isEquipped
        )
        {
            Boots target
               = new Boots(name, id, durability, buyPrice, imageName, modifier, category, power, isEquipped);
            return target;
            // TODO: add assertions to method BootsTest.ConstructorTest01(String, Guid, Double, Int32, String, Modifier, ItemCategory, Int32, Boolean)
        }
    }
}

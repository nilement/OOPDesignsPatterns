using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;
using Objects;
using Objects.Items;
// <copyright file="PantsTest.cs">Copyright ©  2018</copyright>

namespace Tests
{
    /// <summary>This class contains parameterized unit tests for Pants</summary>
    [TestFixture]
    [PexClass(typeof(Pants))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class PantsTest
    {

        /// <summary>Test stub for .ctor()</summary>
        [PexMethod]
        internal Pants ConstructorTest()
        {
            Pants target = new Pants();
            return target;
            // TODO: add assertions to method PantsTest.ConstructorTest()
        }

        /// <summary>Test stub for .ctor(String, Guid, Double, Int32, String, Modifier, ItemCategory, Int32, Boolean)</summary>
        [PexMethod]
        internal Pants ConstructorTest01(
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
            Pants target
               = new Pants(name, id, durability, buyPrice, imageName, modifier, category, power, isEquipped);
            return target;
            // TODO: add assertions to method PantsTest.ConstructorTest01(String, Guid, Double, Int32, String, Modifier, ItemCategory, Int32, Boolean)
        }
    }
}

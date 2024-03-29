using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;
using Objects;
using Objects.Items;
// <copyright file="GlovesTest.cs">Copyright ©  2018</copyright>

namespace Tests
{
    /// <summary>This class contains parameterized unit tests for Gloves</summary>
    [TestFixture]
    [PexClass(typeof(Gloves))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class GlovesTest
    {

        /// <summary>Test stub for .ctor()</summary>
        [PexMethod]
        internal Gloves ConstructorTest()
        {
            Gloves target = new Gloves();
            return target;
            // TODO: add assertions to method GlovesTest.ConstructorTest()
        }

        /// <summary>Test stub for .ctor(String, Guid, Double, Int32, String, Modifier, ItemCategory, Int32, Boolean)</summary>
        [PexMethod]
        internal Gloves ConstructorTest01(
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
            Gloves target
               = new Gloves(name, id, durability, buyPrice, imageName, modifier, category, power, isEquipped);
            return target;
            // TODO: add assertions to method GlovesTest.ConstructorTest01(String, Guid, Double, Int32, String, Modifier, ItemCategory, Int32, Boolean)
        }
    }
}

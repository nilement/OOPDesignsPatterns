using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;
using Objects;
using Objects.Items;
// <copyright file="WeaponTest.cs">Copyright ©  2018</copyright>

namespace Tests
{
    /// <summary>This class contains parameterized unit tests for Weapon</summary>
    [TestFixture]
    [PexClass(typeof(Weapon))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class WeaponTest
    {

        /// <summary>Test stub for .ctor()</summary>
        [PexMethod]
        internal Weapon ConstructorTest()
        {
            Weapon target = new Weapon();
            return target;
            // TODO: add assertions to method WeaponTest.ConstructorTest()
        }

        /// <summary>Test stub for .ctor(String, Guid, Double, Int32, String, Modifier, ItemCategory, Int32, Boolean)</summary>
        [PexMethod]
        internal Weapon ConstructorTest01(
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
            Weapon target
               = new Weapon(name, id, durability, buyPrice, imageName, modifier, category, power, isEquipped);
            return target;
            // TODO: add assertions to method WeaponTest.ConstructorTest01(String, Guid, Double, Int32, String, Modifier, ItemCategory, Int32, Boolean)
        }
    }
}

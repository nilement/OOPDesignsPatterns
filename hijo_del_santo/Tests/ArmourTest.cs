using Objects;
// <copyright file="ArmourTest.cs">Copyright ©  2018</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;
using Objects.Items;

namespace Tests
{
    /// <summary>This class contains parameterized unit tests for Armour</summary>
    [TestFixture]
    [PexClass(typeof(Armour))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class ArmourTest
    {

        /// <summary>Test stub for .ctor(String, Guid, Double, Int32, String, Modifier, ItemCategory, Int32, Boolean)</summary>
        [PexMethod]
        internal Armour ConstructorTest(
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
            Armour target
               = new Armour(name, id, durability, buyPrice, imageName, modifier, category, power, isEquipped);
            return target;
            // TODO: add assertions to method ArmourTest.ConstructorTest(String, Guid, Double, Int32, String, Modifier, ItemCategory, Int32, Boolean)
        }
    }
}

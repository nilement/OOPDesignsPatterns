using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;
using Objects;
using Objects.Items;
// <copyright file="ItemFactoryTest.cs">Copyright ©  2018</copyright>

namespace Tests
{
    /// <summary>This class contains parameterized unit tests for ItemFactory</summary>
    [TestFixture]
    [PexClass(typeof(ItemFactory))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class ItemFactoryTest
    {
        /// <summary>Test stub for CreateItem(Guid, String, Double, Int32, String, Int32, ItemCategory, Int32, Boolean)</summary>
        [PexMethod]
        public Item CreateItemTest(
            Guid id,
            string name,
            double durability,
            int buyPrice,
            string imageName,
            int modifierId,
            ItemCategory itemCategory,
            int power,
            bool isEquipped
        )
        {
            Item result = ItemFactory.CreateItem
                (id, name, durability, buyPrice, imageName, modifierId, itemCategory, power, isEquipped);
            return result;
            // TODO: add assertions to method ItemFactoryTest.CreateItemTest(Guid, String, Double, Int32, String, Int32, ItemCategory, Int32, Boolean)
        }

        /// <summary>Test stub for GenerateItem(Nullable`1&lt;ItemCategory&gt;)</summary>
        [PexMethod]
        public Item GenerateItemTest(ItemCategory? itemCategory)
        {
            Item result = ItemFactory.GenerateItem(itemCategory);
            return result;
            // TODO: add assertions to method ItemFactoryTest.GenerateItemTest(Nullable`1<ItemCategory>)
        }

    }
}
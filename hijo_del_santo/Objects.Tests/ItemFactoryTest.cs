using Objects.Items;
// <copyright file="ItemFactoryTest.cs">Copyright ©  2018</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Objects;

namespace Objects.Tests
{
    [TestClass]
    [PexClass(typeof(ItemFactory))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class ItemFactoryTest
    {

        [PexMethod]
        public Item GenerateItem(ItemCategory? itemCategory)
        {
            Item result = ItemFactory.GenerateItem(itemCategory);
            return result;
            // TODO: add assertions to method ItemFactoryTest.GenerateItem(Nullable`1<ItemCategory>)
        }

        [PexMethod]
        [PexAllowedException(typeof(ArgumentOutOfRangeException))]
        public Item CreateItem(
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
            // TODO: add assertions to method ItemFactoryTest.CreateItem(Guid, String, Double, Int32, String, Int32, ItemCategory, Int32, Boolean)
        }
    }
}

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;
using Objects;
using Objects.Items;
// <copyright file="ShopTest.cs">Copyright ©  2018</copyright>

namespace Tests
{
    /// <summary>This class contains parameterized unit tests for Shop</summary>
    [TestFixture]
    [PexClass(typeof(Shop))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class ShopTest
    {

        /// <summary>Test stub for BuyItem(Guid)</summary>
        [PexMethod]
        public Item BuyItemTest([PexAssumeUnderTest]Shop target, Guid itemId)
        {
            Item result = target.BuyItem(itemId);
            return result;
            // TODO: add assertions to method ShopTest.BuyItemTest(Shop, Guid)
        }

        /// <summary>Test stub for GetShop()</summary>
        [PexMethod]
        public Shop GetShopTest()
        {
            Shop result = Shop.GetShop();
            return result;
            // TODO: add assertions to method ShopTest.GetShopTest()
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;
using Objects;
using Objects.Items;
using Server.Facades.Shop;

// <copyright file="ShopFacadeTest.cs">Copyright ©  2018</copyright>

namespace Tests
{
    /// <summary>This class contains parameterized unit tests for ShopFacade</summary>
    [PexClass(typeof(ShopFacade))]
    [TestFixture]
    public partial class ShopFacadeTest
    {
        /// <summary>Test stub for SellItem(Request`1&lt;Guid&gt;)</summary>
        [PexMethod]
        public Response<bool> SellItemTest(
            [PexAssumeUnderTest] ShopFacade target,
            Request<Guid> sellRequest
        )
        {
            Response<bool> result = target.SellItem(sellRequest);
            return result;
            // TODO: add assertions to method ShopFacadeTest.SellItemTest(ShopFacade, Request`1<Guid>)
        }

        /// <summary>Test stub for GetItems(Request)</summary>
        [PexMethod]
        public Response<List<Item>> GetItemsTest([PexAssumeUnderTest] ShopFacade target, Request itemsRequest)
        {
            Response<List<Item>> result = target.GetItems(itemsRequest);
            return result;
            // TODO: add assertions to method ShopFacadeTest.GetItemsTest(ShopFacade, Request)
        }
    }
}
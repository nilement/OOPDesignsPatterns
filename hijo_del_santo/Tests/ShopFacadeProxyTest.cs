using System;
using System.Collections.Generic;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;
using Objects;
using Objects.Items;
using Server.Facades.Shop;
// <copyright file="ShopFacadeProxyTest.cs">Copyright ©  2018</copyright>

namespace Tests
{
    /// <summary>This class contains parameterized unit tests for ShopFacadeProxy</summary>
    [TestFixture]
    [PexClass(typeof(ShopFacadeProxy))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class ShopFacadeProxyTest
    {

        /// <summary>Test stub for GetItems(Request)</summary>
        [PexMethod]
        public Response<List<Item>> GetItemsTest([PexAssumeUnderTest]ShopFacadeProxy target, Request itemsRequest)
        {
            Response<List<Item>> result = target.GetItems(itemsRequest);
            return result;
            // TODO: add assertions to method ShopFacadeProxyTest.GetItemsTest(ShopFacadeProxy, Request)
        }
    }
}

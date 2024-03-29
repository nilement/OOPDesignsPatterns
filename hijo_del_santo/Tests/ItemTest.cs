// <copyright file="ItemTest.cs">Copyright ©  2018</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;
using Objects.Items;

namespace Tests
{
    /// <summary>This class contains parameterized unit tests for Item</summary>
    [TestFixture]
    [PexClass(typeof(Item))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class ItemTest
    {

        /// <summary>Test stub for get_SellPrice()</summary>
        [PexMethod]
        public int SellPriceGetTest([PexAssumeNotNull]Item target)
        {
            int result = target.SellPrice;
            return result;
            // TODO: add assertions to method ItemTest.SellPriceGetTest(Item)
        }
    }
}

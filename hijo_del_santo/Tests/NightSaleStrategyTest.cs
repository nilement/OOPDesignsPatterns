// <copyright file="NightSaleStrategyTest.cs">Copyright ©  2018</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;
using Objects.Strategy;

namespace Tests
{
    /// <summary>This class contains parameterized unit tests for NightSaleStrategy</summary>
    [TestFixture]
    [PexClass(typeof(NightSaleStrategy))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class NightSaleStrategyTest
    {

        /// <summary>Test stub for GetPrice(Int32)</summary>
        [PexMethod]
        public int GetPriceTest([PexAssumeUnderTest]NightSaleStrategy target, int price)
        {
            int result = target.GetPrice(price);
            return result;
            // TODO: add assertions to method NightSaleStrategyTest.GetPriceTest(NightSaleStrategy, Int32)
        }
    }
}

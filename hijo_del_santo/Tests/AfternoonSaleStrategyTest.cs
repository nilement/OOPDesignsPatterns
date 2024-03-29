// <copyright file="AfternoonSaleStrategyTest.cs">Copyright ©  2018</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;
using Objects.Strategy;

namespace Tests
{
    /// <summary>This class contains parameterized unit tests for AfternoonSaleStrategy</summary>
    [TestFixture]
    [PexClass(typeof(AfternoonSaleStrategy))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class AfternoonSaleStrategyTest
    {

        /// <summary>Test stub for GetPrice(Int32)</summary>
        [PexMethod]
        public int GetPriceTest([PexAssumeUnderTest]AfternoonSaleStrategy target, int price)
        {
            int result = target.GetPrice(price);
            return result;
            // TODO: add assertions to method AfternoonSaleStrategyTest.GetPriceTest(AfternoonSaleStrategy, Int32)
        }
    }
}

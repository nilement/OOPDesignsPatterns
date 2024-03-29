// <copyright file="MorningSaleStrategyTest.cs">Copyright ©  2018</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;
using Objects.Strategy;

namespace Tests
{
    /// <summary>This class contains parameterized unit tests for MorningSaleStrategy</summary>
    [TestFixture]
    [PexClass(typeof(MorningSaleStrategy))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class MorningSaleStrategyTest
    {

        /// <summary>Test stub for GetPrice(Int32)</summary>
        [PexMethod]
        public int GetPriceTest([PexAssumeUnderTest]MorningSaleStrategy target, int price)
        {
            int result = target.GetPrice(price);
            return result;
            // TODO: add assertions to method MorningSaleStrategyTest.GetPriceTest(MorningSaleStrategy, Int32)
        }
    }
}

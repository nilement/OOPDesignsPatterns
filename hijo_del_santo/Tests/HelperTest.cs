using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;
using Server;

namespace Tests
{
    /// <summary>This class contains parameterized unit tests for Helper</summary>
    [TestFixture]
    [PexClass(typeof(Helper))]
    public partial class HelperTest
    {

        /// <summary>Test stub for ToByteArray(String)</summary>
        [PexMethod]
        [TestCase("test", ExpectedResult = new byte[] { 116, 101, 115, 116 })]
        [TestCase("Testavimas", ExpectedResult = new byte[] { 84, 101, 115, 116, 97, 118, 105, 109, 97, 115 })]
        [TestCase("123", ExpectedResult = new byte[] { 49, 50, 51 })]
        public byte[] ToByteArrayTest(string obj)
        {
            return obj.ToByteArray();
        }

        /// <summary>Test stub for ToStringRedux(Byte[])</summary>
        [PexMethod]
        internal string ToStringReduxTest(byte[] obj)
        {
            string result = Helper.ToStringRedux(obj);
            return result;
            // TODO: add assertions to method HelperTest.ToStringReduxTest(Byte[])
        }
    }
}

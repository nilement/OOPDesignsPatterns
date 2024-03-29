// <copyright file="UtilsTest.cs">Copyright ©  2018</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;
using Objects;

namespace Tests
{
    /// <summary>This class contains parameterized unit tests for Utils</summary>
    [TestFixture]
    [PexClass(typeof(Utils))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class UtilsTest
    {

        /// <summary>Test stub for ByteArrayToObject(Byte[])</summary>
        [PexMethod]
        public object ByteArrayToObjectTest(byte[] arrBytes)
        {
            object result = Utils.ByteArrayToObject(arrBytes);
            return result;
            // TODO: add assertions to method UtilsTest.ByteArrayToObjectTest(Byte[])
        }

        /// <summary>Test stub for GetInsertQuery(Object, String, Boolean, Tuple`2&lt;String,Object&gt;[])</summary>
        [PexMethod]
        public string GetInsertQueryTest(
            object obj,
            string table,
            bool skipIdField,
            Tuple<string, object>[] extraColumnsAndValues
        )
        {
            string result = Utils.GetInsertQuery(obj, table, skipIdField, extraColumnsAndValues);
            return result;
            // TODO: add assertions to method UtilsTest.GetInsertQueryTest(Object, String, Boolean, Tuple`2<String,Object>[])
        }

        /// <summary>Test stub for ObjectToByteArray(Object)</summary>
        [PexMethod]
        public byte[] ObjectToByteArrayTest(object obj)
        {
            byte[] result = Utils.ObjectToByteArray(obj);
            return result;
            // TODO: add assertions to method UtilsTest.ObjectToByteArrayTest(Object)
        }
    }
}

// <copyright file="UtilsTest.cs">Copyright ©  2018</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Objects;

namespace Objects.Tests
{
    [TestClass]
    [PexClass(typeof(Utils))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class UtilsTest
    {

        [PexMethod]
        [PexAllowedException(typeof(NullReferenceException))]
        public object ByteArrayToObject(byte[] arrBytes)
        {
            object result = Utils.ByteArrayToObject(arrBytes);
            return result;
            // TODO: add assertions to method UtilsTest.ByteArrayToObject(Byte[])
        }

        [PexMethod]
        public string GetInsertQuery(
            object obj,
            string table,
            bool skipIdField,
            Tuple<string, object>[] extraColumnsAndValues
        )
        {
            string result = Utils.GetInsertQuery(obj, table, skipIdField, extraColumnsAndValues);
            return result;
            // TODO: add assertions to method UtilsTest.GetInsertQuery(Object, String, Boolean, Tuple`2<String,Object>[])
        }
    }
}

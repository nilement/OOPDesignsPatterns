using System;
using System.Data.SqlClient;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;
using Server;
// <copyright file="DatabaseTest.cs">Copyright ©  2018</copyright>

namespace Tests
{
    /// <summary>This class contains parameterized unit tests for Database</summary>
    [TestFixture]
    [PexClass(typeof(Database))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class DatabaseTest
    {

        /// <summary>Test stub for .ctor()</summary>
        [PexMethod]
        internal Database ConstructorTest()
        {
            Database target = new Database();
            return target;
            // TODO: add assertions to method DatabaseTest.ConstructorTest()
        }

        /// <summary>Test stub for Dispose()</summary>
        [PexMethod]
        internal void DisposeTest([PexAssumeUnderTest]Database target)
        {
            target.Dispose();
            // TODO: add assertions to method DatabaseTest.DisposeTest(Database)
        }

        /// <summary>Test stub for GetConnection()</summary>
        [PexMethod]
        internal SqlConnection GetConnectionTest([PexAssumeUnderTest]Database target)
        {
            SqlConnection result = target.GetConnection();
            return result;
            // TODO: add assertions to method DatabaseTest.GetConnectionTest(Database)
        }
    }
}

// <copyright file="CommonTest.cs">Copyright ©  2018</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;
using Objects;

namespace Tests
{
    /// <summary>This class contains parameterized unit tests for Common</summary>
    [TestFixture]
    [PexClass(typeof(Common))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class CommonTest
    {
    }
}

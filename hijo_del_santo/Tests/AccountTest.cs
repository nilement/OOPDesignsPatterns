// <copyright file="AccountTest.cs">Copyright ©  2018</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;
using Objects;

namespace Tests
{
    /// <summary>This class contains parameterized unit tests for Account</summary>
    [TestFixture]
    [PexClass(typeof(Account))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class AccountTest
    {
    }
}

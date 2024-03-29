// <copyright file="AnimationTest.cs">Copyright ©  2018</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using hijo_del_santo.Assets;

namespace hijo_del_santo.Assets.Tests
{
    [TestClass]
    [PexClass(typeof(Animation))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class AnimationTest
    {
    }
}

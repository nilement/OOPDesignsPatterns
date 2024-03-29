using System;
using System.Collections.Generic;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;
using Objects;
using Objects.Items;
using Server.Facades.User;
// <copyright file="UserFacadeProxyTest.cs">Copyright ©  2018</copyright>

namespace Tests
{
    /// <summary>This class contains parameterized unit tests for UserFacadeProxy</summary>
    [TestFixture]
    [PexClass(typeof(UserFacadeProxy))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class UserFacadeProxyTest
    {

        /// <summary>Test stub for .ctor()</summary>
        [PexMethod]
        public UserFacadeProxy ConstructorTest()
        {
            UserFacadeProxy target = new UserFacadeProxy();
            return target;
            // TODO: add assertions to method UserFacadeProxyTest.ConstructorTest()
        }

        /// <summary>Test stub for CreateCharacter(Request`1&lt;String&gt;)</summary>
        [PexMethod]
        public Response<bool> CreateCharacterTest([PexAssumeUnderTest]UserFacadeProxy target, Request<string> characterName)
        {
            Response<bool> result = target.CreateCharacter(characterName);
            return result;
            // TODO: add assertions to method UserFacadeProxyTest.CreateCharacterTest(UserFacadeProxy, Request`1<String>)
        }

        /// <summary>Test stub for EquipItem(Request`1&lt;Character&gt;, Guid)</summary>
        [PexMethod]
        public Response<List<Item>> EquipItemTest(
            [PexAssumeUnderTest]UserFacadeProxy target,
            Request<Character> characterRequest,
            Guid itemId
        )
        {
            Response<List<Item>> result = target.EquipItem(characterRequest, itemId);
            return result;
            // TODO: add assertions to method UserFacadeProxyTest.EquipItemTest(UserFacadeProxy, Request`1<Character>, Guid)
        }

        /// <summary>Test stub for GetAccountCharacters(Request)</summary>
        [PexMethod]
        public Response<List<Character>> GetAccountCharactersTest([PexAssumeUnderTest]UserFacadeProxy target, Request accountId)
        {
            Response<List<Character>> result = target.GetAccountCharacters(accountId);
            return result;
            // TODO: add assertions to method UserFacadeProxyTest.GetAccountCharactersTest(UserFacadeProxy, Request)
        }

        /// <summary>Test stub for GetCharacter(Request`1&lt;Int32&gt;)</summary>
        [PexMethod]
        public Response<Character> GetCharacterTest([PexAssumeUnderTest]UserFacadeProxy target, Request<int> characterId)
        {
            Response<Character> result = target.GetCharacter(characterId);
            return result;
            // TODO: add assertions to method UserFacadeProxyTest.GetCharacterTest(UserFacadeProxy, Request`1<Int32>)
        }

        /// <summary>Test stub for GetItems(Request`1&lt;Int32&gt;)</summary>
        [PexMethod]
        public Response<List<Item>> GetItemsTest([PexAssumeUnderTest]UserFacadeProxy target, Request<int> characterId)
        {
            Response<List<Item>> result = target.GetItems(characterId);
            return result;
            // TODO: add assertions to method UserFacadeProxyTest.GetItemsTest(UserFacadeProxy, Request`1<Int32>)
        }

        /// <summary>Test stub for Login(Account)</summary>
        [PexMethod]
        public Response<Guid> LoginTest([PexAssumeUnderTest]UserFacadeProxy target, Account account)
        {
            Response<Guid> result = target.Login(account);
            return result;
            // TODO: add assertions to method UserFacadeProxyTest.LoginTest(UserFacadeProxy, Account)
        }

        /// <summary>Test stub for Registration(Account)</summary>
        [PexMethod]
        public Response<Guid> RegistrationTest([PexAssumeUnderTest]UserFacadeProxy target, Account account)
        {
            Response<Guid> result = target.Registration(account);
            return result;
            // TODO: add assertions to method UserFacadeProxyTest.RegistrationTest(UserFacadeProxy, Account)
        }

        /// <summary>Test stub for SelectCharacter(Request`1&lt;Character&gt;)</summary>
        [PexMethod]
        public Response<bool> SelectCharacterTest([PexAssumeUnderTest]UserFacadeProxy target, Request<Character> characterRequest)
        {
            Response<bool> result = target.SelectCharacter(characterRequest);
            return result;
            // TODO: add assertions to method UserFacadeProxyTest.SelectCharacterTest(UserFacadeProxy, Request`1<Character>)
        }
    }
}

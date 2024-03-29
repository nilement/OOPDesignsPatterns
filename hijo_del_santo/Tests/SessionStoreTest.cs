// <copyright file="SessionStoreTest.cs">Copyright ©  2018</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;
using Objects;

namespace Tests
{
    /// <summary>This class contains parameterized unit tests for SessionStore</summary>
    [TestFixture]
    [PexClass(typeof(SessionStore))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class SessionStoreTest
    {

        /// <summary>Test stub for GetCharacter(Guid)</summary>
        [PexMethod]
        public Character GetCharacterTest([PexAssumeUnderTest]SessionStore target, Guid id)
        {
            Character result = target.GetCharacter(id);
            return result;
            // TODO: add assertions to method SessionStoreTest.GetCharacterTest(SessionStore, Guid)
        }

        /// <summary>Test stub for GetSessionStore()</summary>
        [PexMethod]
        public SessionStore GetSessionStoreTest()
        {
            SessionStore result = SessionStore.GetSessionStore();
            return result;
            // TODO: add assertions to method SessionStoreTest.GetSessionStoreTest()
        }

        /// <summary>Test stub for GetUsername(Guid)</summary>
        [PexMethod]
        public string GetUsernameTest([PexAssumeUnderTest]SessionStore target, Guid id)
        {
            string result = target.GetUsername(id);
            return result;
            // TODO: add assertions to method SessionStoreTest.GetUsernameTest(SessionStore, Guid)
        }

        /// <summary>Test stub for LoggedIn(Guid)</summary>
        [PexMethod]
        public bool LoggedInTest([PexAssumeUnderTest]SessionStore target, Guid sessionId)
        {
            bool result = target.LoggedIn(sessionId);
            return result;
            // TODO: add assertions to method SessionStoreTest.LoggedInTest(SessionStore, Guid)
        }

        /// <summary>Test stub for Login(String)</summary>
        [PexMethod]
        public Response<Guid> LoginTest([PexAssumeUnderTest]SessionStore target, string username)
        {
            Response<Guid> result = target.Login(username);
            return result;
            // TODO: add assertions to method SessionStoreTest.LoginTest(SessionStore, String)
        }

        /// <summary>Test stub for SetSessionCharacter(Guid, Character)</summary>
        [PexMethod]
        public bool SetSessionCharacterTest(
            [PexAssumeUnderTest]SessionStore target,
            Guid sessionId,
            Character character
        )
        {
            bool result = target.SetSessionCharacter(sessionId, character);
            return result;
            // TODO: add assertions to method SessionStoreTest.SetSessionCharacterTest(SessionStore, Guid, Character)
        }
    }
}

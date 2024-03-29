// <copyright file="CharacterTest.cs">Copyright ©  2018</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;
using Objects;

namespace Tests
{
    /// <summary>This class contains parameterized unit tests for Character</summary>
    [TestFixture]
    [PexClass(typeof(Character))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class CharacterTest
    {

        /// <summary>Test stub for .ctor(String, Int32, Int32, Int32, Int32, Int32, Int32)</summary>
        [PexMethod]
        public Character ConstructorTest(
            string name,
            int strength,
            int agility,
            int intelligence,
            int level,
            int experience,
            int gold
        )
        {
            Character target = new Character(name, strength, agility, intelligence, level, experience, gold);
            return target;
            // TODO: add assertions to method CharacterTest.ConstructorTest(String, Int32, Int32, Int32, Int32, Int32, Int32)
        }

        /// <summary>Test stub for .ctor(Int32, String, Int32, Int32, Int32, Int32, Int32, Int32)</summary>
        [PexMethod]
        public Character ConstructorTest01(
            int id,
            string name,
            int strength,
            int agility,
            int intelligence,
            int level,
            int experience,
            int gold
        )
        {
            Character target = new Character(id, name, strength, agility, intelligence, level, experience, gold)
              ;
            return target;
            // TODO: add assertions to method CharacterTest.ConstructorTest01(Int32, String, Int32, Int32, Int32, Int32, Int32, Int32)
        }
    }
}

using Microsoft.Pex.Framework.Generated;
using NUnit.Framework;
using Microsoft.Pex.Framework;
using Objects;
// <copyright file="MatchmakerTest.GenerateOpponent.g.cs">Copyright ©  2018</copyright>
// <auto-generated>
// This file contains automatically generated tests.
// Do not modify this file manually.
// 
// If the contents of this file becomes outdated, you can delete it.
// For example, if it no longer compiles.
// </auto-generated>
using System;

namespace Objects.Tests
{
    public partial class MatchmakerTest
    {

[Test]
[PexGeneratedBy(typeof(MatchmakerTest))]
public void GenerateOpponent26()
{
    Matchmaker matchmaker;
    Opponent opponent;
    matchmaker = new Matchmaker();
    opponent = this.GenerateOpponent(matchmaker);
    PexAssert.IsNotNull((object)opponent);
    PexAssert.IsNotNull((object)matchmaker);
}
    }
}

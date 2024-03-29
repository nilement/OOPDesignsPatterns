using System;
using Microsoft.Pex.Engine.Exceptions;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Generated;
using NUnit.Framework;
using Objects;
using Objects.Items;
// <copyright file="ItemFactoryTest.CreateItemTest.g.cs">Copyright ©  2018</copyright>
// <auto-generated>
// This file contains automatically generated tests.
// Do not modify this file manually.
// 
// If the contents of this file becomes outdated, you can delete it.
// For example, if it no longer compiles.
// </auto-generated>

namespace Tests
{
    public partial class ItemFactoryTest
    {

[Test]
[PexGeneratedBy(typeof(ItemFactoryTest))]
public void CreateItemTest167()
{
    Item item;
    Guid s0
       = new Guid(default(int), (short)32, (short)32, default(byte), default(byte), 
                  default(byte), default(byte), default(byte), 
                  default(byte), default(byte), default(byte));
    item = this.CreateItemTest
               (s0, (string)null, 0, 0, (string)null, 0, ItemCategory.Weapon, 0, false);
    PexAssert.IsNotNull((object)item);
    PexAssert.AreEqual<string>((string)null, item.Name);
    PexAssert.AreEqual<double>(0, item.Durability);
    PexAssert.AreEqual<int>(0, item.BuyPrice);
    PexAssert.AreEqual<string>((string)null, item.ImageName);
    PexAssert.IsNotNull(item.Modifier);
    PexAssert.AreEqual<string>("Piktas", item.Modifier.Name);
    PexAssert.AreEqual<double>(21, item.Modifier.Percentage);
    PexAssert.AreEqual<ItemCategory>(ItemCategory.Weapon, item.Category);
    PexAssert.AreEqual<int>(0, item.Power);
    PexAssert.AreEqual<bool>(false, item.IsEquipped);
}

[Test]
[PexGeneratedBy(typeof(ItemFactoryTest))]
public void CreateItemTest590()
{
    Item item;
    Guid s0
       = new Guid(default(int), (short)32, (short)32, default(byte), default(byte), 
                  default(byte), default(byte), default(byte), 
                  default(byte), default(byte), default(byte));
    item = this.CreateItemTest
               (s0, (string)null, 0, 0, (string)null, 0, ItemCategory.Helmet, 0, false);
    PexAssert.IsNotNull((object)item);
    PexAssert.AreEqual<string>((string)null, item.Name);
    PexAssert.AreEqual<double>(0, item.Durability);
    PexAssert.AreEqual<int>(0, item.BuyPrice);
    PexAssert.AreEqual<string>((string)null, item.ImageName);
    PexAssert.IsNotNull(item.Modifier);
    PexAssert.AreEqual<string>("Piktas", item.Modifier.Name);
    PexAssert.AreEqual<double>(21, item.Modifier.Percentage);
    PexAssert.AreEqual<ItemCategory>(ItemCategory.Helmet, item.Category);
    PexAssert.AreEqual<int>(0, item.Power);
    PexAssert.AreEqual<bool>(false, item.IsEquipped);
}

[Test]
[PexGeneratedBy(typeof(ItemFactoryTest))]
public void CreateItemTest187()
{
    Item item;
    Guid s0
       = new Guid(default(int), (short)32, (short)32, default(byte), default(byte), 
                  default(byte), default(byte), default(byte), 
                  default(byte), default(byte), default(byte));
    item = this.CreateItemTest
               (s0, (string)null, 0, 0, (string)null, 0, ItemCategory.Armour, 0, false);
    PexAssert.IsNotNull((object)item);
    PexAssert.AreEqual<string>((string)null, item.Name);
    PexAssert.AreEqual<double>(0, item.Durability);
    PexAssert.AreEqual<int>(0, item.BuyPrice);
    PexAssert.AreEqual<string>((string)null, item.ImageName);
    PexAssert.IsNotNull(item.Modifier);
    PexAssert.AreEqual<string>("Piktas", item.Modifier.Name);
    PexAssert.AreEqual<double>(21, item.Modifier.Percentage);
    PexAssert.AreEqual<ItemCategory>(ItemCategory.Armour, item.Category);
    PexAssert.AreEqual<int>(0, item.Power);
    PexAssert.AreEqual<bool>(false, item.IsEquipped);
}

[Test]
[PexGeneratedBy(typeof(ItemFactoryTest))]
public void CreateItemTest145()
{
    Item item;
    Guid s0
       = new Guid(default(int), (short)32, (short)32, default(byte), default(byte), 
                  default(byte), default(byte), default(byte), 
                  default(byte), default(byte), default(byte));
    item = this.CreateItemTest
               (s0, (string)null, 0, 0, (string)null, 0, ItemCategory.Pants, 0, false);
    PexAssert.IsNotNull((object)item);
    PexAssert.AreEqual<string>((string)null, item.Name);
    PexAssert.AreEqual<double>(0, item.Durability);
    PexAssert.AreEqual<int>(0, item.BuyPrice);
    PexAssert.AreEqual<string>((string)null, item.ImageName);
    PexAssert.IsNotNull(item.Modifier);
    PexAssert.AreEqual<string>("Piktas", item.Modifier.Name);
    PexAssert.AreEqual<double>(21, item.Modifier.Percentage);
    PexAssert.AreEqual<ItemCategory>(ItemCategory.Pants, item.Category);
    PexAssert.AreEqual<int>(0, item.Power);
    PexAssert.AreEqual<bool>(false, item.IsEquipped);
}

[Test]
[PexGeneratedBy(typeof(ItemFactoryTest))]
public void CreateItemTest952()
{
    Item item;
    Guid s0
       = new Guid(default(int), (short)32, (short)32, default(byte), default(byte), 
                  default(byte), default(byte), default(byte), 
                  default(byte), default(byte), default(byte));
    item = this.CreateItemTest
               (s0, (string)null, 0, 0, (string)null, 0, ItemCategory.Gloves, 0, false);
    PexAssert.IsNotNull((object)item);
    PexAssert.AreEqual<string>((string)null, item.Name);
    PexAssert.AreEqual<double>(0, item.Durability);
    PexAssert.AreEqual<int>(0, item.BuyPrice);
    PexAssert.AreEqual<string>((string)null, item.ImageName);
    PexAssert.IsNotNull(item.Modifier);
    PexAssert.AreEqual<string>("Piktas", item.Modifier.Name);
    PexAssert.AreEqual<double>(21, item.Modifier.Percentage);
    PexAssert.AreEqual<ItemCategory>(ItemCategory.Gloves, item.Category);
    PexAssert.AreEqual<int>(0, item.Power);
    PexAssert.AreEqual<bool>(false, item.IsEquipped);
}

[Test]
[PexGeneratedBy(typeof(ItemFactoryTest))]
[PexRaisedException(typeof(ArgumentOutOfRangeException), PexExceptionState.Inconclusive)]
public void CreateItemTestThrowsArgumentOutOfRangeException239()
{
    try
    {
      Item item;
      Guid s0 = new Guid
                    (default(int), (short)32, (short)32, default(byte), default(byte), 
                     default(byte), default(byte), default(byte), 
                     default(byte), default(byte), default(byte));
      item = this.CreateItemTest
                 (s0, (string)null, 0, 0, (string)null, 0, (ItemCategory)6, 0, false);
      throw new AssertionException
                ("expected an exception of type ArgumentOutOfRangeException");
    }
    catch(ArgumentOutOfRangeException )
    {
    }
}

[Test]
[PexGeneratedBy(typeof(ItemFactoryTest))]
public void CreateItemTest19()
{
    Item item;
    Guid s0
       = new Guid(default(int), (short)32, (short)32, default(byte), default(byte), 
                  default(byte), default(byte), default(byte), 
                  default(byte), default(byte), default(byte));
    item = this.CreateItemTest
               (s0, (string)null, 0, 0, (string)null, 0, ItemCategory.Boots, 0, false);
    PexAssert.IsNotNull((object)item);
    PexAssert.AreEqual<string>((string)null, item.Name);
    PexAssert.AreEqual<double>(0, item.Durability);
    PexAssert.AreEqual<int>(0, item.BuyPrice);
    PexAssert.AreEqual<string>((string)null, item.ImageName);
    PexAssert.IsNotNull(item.Modifier);
    PexAssert.AreEqual<string>("Piktas", item.Modifier.Name);
    PexAssert.AreEqual<double>(21, item.Modifier.Percentage);
    PexAssert.AreEqual<ItemCategory>(ItemCategory.Boots, item.Category);
    PexAssert.AreEqual<int>(0, item.Power);
    PexAssert.AreEqual<bool>(false, item.IsEquipped);
}
    }
}

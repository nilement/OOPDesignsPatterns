using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Objects;
using Objects.Items;
using Server.Commands;
using Server.Loggers;

namespace Server.Facades.Shop
{
    public class ShopFacade : IShopFacade
    {
        private static readonly object LockBuyItemObj = new object();
        private readonly SessionStore _sessionStore;
        private readonly Objects.Shop _shop;

        public ShopFacade()
        {
            _sessionStore = SessionStore.GetSessionStore();
            _shop = Objects.Shop.GetShop();
        }

        public Response<List<Item>> GetItems(Request itemsRequest)
        {
            lock (LockBuyItemObj)
            {
                return Response<List<Item>>.AddResult(_shop.Items);
            }
        }

        public Response<bool> BuyItem(Request<Guid> buyRequest)
        {
            var character = _sessionStore.GetCharacter(buyRequest.SessionId);
            Item item;

            lock (LockBuyItemObj)
            {
                item = _shop.Items.FirstOrDefault(x => x.Id == buyRequest.Data);
                if (item == null)
                {
                    return Response<bool>.ReturnBadRequest("Item was already bought");
                }

                if (character.Gold < item.BuyPrice)
                {
                    return Response<bool>.ReturnBadRequest("Gold needed");
                }

                _shop.BuyItem(item.Id);
            }

            return ChargeCharacter(item, character);
        }

        public Response<bool> SellItem(Request<Guid> sellRequest)
        {
            var character = _sessionStore.GetCharacter(sellRequest.SessionId);
            using (var database = new Database())
            {
                var connection = database.GetConnection();
                var query = $"select * from {Database.ItemTable} where CharacterId = '{character.Id}' and Id = '{sellRequest.Data}'";
                Item item;
                using (var reader = new SqlCommand(query, connection).ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return Response<bool>.ReturnBadRequest("Item doesn't exist");
                    }

                    item = ItemFactory.CreateItem(reader.GetGuid(0), reader.GetString(1), reader.GetDouble(2), reader.GetInt32(3),
                        reader.GetString(4),
                        reader.GetInt32(5), reader.GetInt32(6), (ItemCategory) reader.GetInt32(7), reader.GetBoolean(9));
                }

                var sellCommand = new SellItemInvoker(connection, item, character.Id);
                ConsoleLogger.GetLogger().Message($"Item {item.Name} has been sold for {item.SellPrice} to {character.Name}", LogType.All);
                return Response<bool>.AddResult(sellCommand.Sell());
            }
        }


        private Response<bool> ChargeCharacter(Item item, Character character)
        {
            var updateGoldQuery = $"update {Database.CharacterTable} Set Gold = {character.Gold - item.BuyPrice} where Id = {character.Id}";
            var newItemInsertionQuery =
                $"insert into {Database.ItemTable} (Id, Name, Durability, BuyPrice, ImageName, Modifier, Power, ItemCategory, CharacterId) " +
                $"values ('{item.Id}', '{item.Name}', {item.Durability}, {item.BuyPrice}, '{item.ImageName}', {item.Modifier.RandomNumber}, {item.Power}, {(int)item.Category}, {character.Id})";

            using (var database = new Database())
            {
                var connection = database.GetConnection();
                try
                {
                    var command = new SqlCommand(updateGoldQuery, connection);
                    command.ExecuteReader().Close();
                    command.CommandText = newItemInsertionQuery;
                    command.ExecuteReader();
                    var logger = ConsoleLogger.GetLogger();
                    logger.Message($"Character {character.Name} was charged: {item.BuyPrice}", LogType.All);
                }
                catch(Exception ex)
                {
                    return Response<bool>.ReturnBadRequest("Oops");
                }

                return Response<bool>.AddResult(true);
            }
        }
    }
}
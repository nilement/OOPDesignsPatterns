using System.Data.SqlClient;
using Objects.Items;

namespace Server.Commands
{
    public class SellItemCommand : IUndoableCommand
    {
        private readonly Item _soldItem;
        private readonly int _characterId;
        private readonly SqlConnection _connection;

        public SellItemCommand(SqlConnection connection, Item soldItem, int characterId)
        {
            _soldItem = soldItem;
            _characterId = characterId;
            _connection = connection;
        }

        public bool Execute()
        {
            var query = $"Delete from {Database.ItemTable} where CharacterId = '{_characterId}' and Id = '{_soldItem.Id}'";
            using (var command = new SqlCommand(query, _connection))
            {
                return command.ExecuteNonQuery() != 0;
            }
        }

        public void Undo()
        {
            var query =
                $"Insert into {Database.ItemTable} (Id, Name, Durability, BuyPrice, ImageName, Modifier, Power, ItemCategory, CharacterId, IsEquipped) " +
                $"Values ('{_soldItem.Id}', '{_soldItem.Name}', {_soldItem.Durability}, {_soldItem.BuyPrice}, '{_soldItem.ImageName}', " +
                $"{_soldItem.Modifier}, {_soldItem.Power}, {_soldItem.Category}, {_characterId}, {_soldItem.IsEquipped})";

            using (var command = new SqlCommand(query, _connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}
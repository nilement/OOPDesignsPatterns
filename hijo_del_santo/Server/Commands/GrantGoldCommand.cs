using System;
using System.Data.SqlClient;
using Objects;
using Objects.Items;

namespace Server.Commands
{
    class GrantGoldCommand : IUndoableCommand
    {
        private readonly SqlConnection _connection;
        private readonly Item _item;
        private readonly int _characterId;

        public GrantGoldCommand(SqlConnection connection, Item item, int characterId)
        {
            _connection = connection;
            _item = item;
            _characterId = characterId;
        }

        public bool Execute()
        {
            var query = $"Update {Database.CharacterTable} set Gold = Gold + {_item.SellPrice} where id = {_characterId}";
            using (var command = new SqlCommand(query, _connection))
            {
                return command.ExecuteNonQuery() != 0;
            }
        }

        public void Undo()
        {
            var query = $"Update {Database.CharacterTable} set Gold = Gold - {_item.SellPrice} where id = {_characterId}";
            using (var command = new SqlCommand(query, _connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}
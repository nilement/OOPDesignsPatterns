using System;
using System.Data.SqlClient;
using Objects.Items;

namespace Server.Commands
{
    class SellItemInvoker
    {
        private readonly IUndoableCommand _sellUndoableCommand;
        private readonly IUndoableCommand _grantUndoableCommand;

        public SellItemInvoker(SqlConnection connection, Item item, int characterId)
        {
            _sellUndoableCommand = new SellItemCommand(connection, item, characterId);
            _grantUndoableCommand = new GrantGoldCommand(connection, item, characterId);
        }

        public bool Sell()
        {
            if (!_sellUndoableCommand.Execute())
            {
                return false;
            } 

            if (!_grantUndoableCommand.Execute())
            {
                _sellUndoableCommand.Undo();
                return false;
            }

            return true;
        }
    }
}

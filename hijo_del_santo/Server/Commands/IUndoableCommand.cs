namespace Server.Commands
{
    interface IUndoableCommand : ICommand
    {
        void Undo();
    }
}

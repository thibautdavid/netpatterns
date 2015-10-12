using System;
using System.Windows.Input;

namespace U2U.WPF.CommandPattern
{
    public interface IUndoableCommand : ICommand
    {
        void Undo();
        bool CanUndo();

        void Redo();
        // bool CanRedo();
    }

    public class UndoableCommand : RelayCommand, IUndoableCommand
    {
        public void Undo()
        {
            throw new NotImplementedException();
        }

        public bool CanUndo()
        {
            throw new NotImplementedException();
        }

        public void Redo()
        {
            throw new NotImplementedException();
        }

        public UndoableCommand(string displayName, Action execute, Func<bool> canExecute) : base(displayName, execute, canExecute)
        {
        }

        public UndoableCommand(string displayName, Action execute) : base(displayName, execute)
        {
        }
    }
}

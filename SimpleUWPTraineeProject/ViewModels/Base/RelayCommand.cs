#nullable enable
using System;
using System.Windows.Input;

namespace SimpleUWPTraineeProject.ViewModels.Base
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object?> _executeAction;
        private readonly Predicate<object?>? _canExecuteAction;

        public event EventHandler? CanExecuteChanged;

        public RelayCommand(Action<object?> executeAction, Predicate<object?>? canExecuteAction = null)
        {
            _executeAction = executeAction;
            _canExecuteAction = canExecuteAction;
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecuteAction?.Invoke(parameter) ?? true;
        }

        public void Execute(object? parameter)
        {
            _executeAction(parameter);
        }
    }
}

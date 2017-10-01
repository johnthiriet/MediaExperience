using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MediaExperience.Commands
{
    public class AsyncCommand<T> : ICommand
    {
        private readonly Func<T, Task> _execute;
        private readonly Func<T, bool> _canExecute;

        public AsyncCommand(Func<T, Task> execute, Func<T, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(T parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        public Task ExecuteAsync(T parameter)
        {
            return _execute(parameter);
        }

        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute((T)parameter);
        }

        void ICommand.Execute(object parameter)
        {
            ExecuteAsync((T)parameter).FireAndForgetSafeAsync();
        }

        public event EventHandler CanExecuteChanged;
    }

    public class AsyncCommand : ICommand
    {
        private readonly Func<Task> _execute;
        private readonly Func<bool> _canExecute;

        public AsyncCommand(Func<Task> execute, Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute()
        {
            return _canExecute?.Invoke() ?? true;
        }

        public Task ExecuteAsync()
        {
            return _execute();
        }

        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute();
        }

        void ICommand.Execute(object parameter)
        {
            ExecuteAsync().FireAndForgetSafeAsync();
        }

        public event EventHandler CanExecuteChanged;
    }
}

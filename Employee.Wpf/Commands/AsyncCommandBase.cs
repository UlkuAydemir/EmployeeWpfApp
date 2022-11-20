using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Employee.Wpf.Commands
{
    public class AsyncCommandBase : ICommand
    {
        private bool _isExecuting;
        public bool IsExecuting
        {
            get
            {
                return _isExecuting;
            }
            set
            {
                _isExecuting = value;
                OnCanExecuteChanged();
            }
        }
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public AsyncCommandBase()
        {
        }
        public AsyncCommandBase(Action<object> execute)
            : this(execute, null)
        {
        }

        public AsyncCommandBase(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter)
        {
            return !IsExecuting;
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        //public async void Execute(object parameter)
        //{
        //    IsExecuting = true;

        //    await ExecuteAsync(parameter);

        //    IsExecuting = false;
        //}

        //public abstract Task ExecuteAsync(object parameter);

        protected void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}

using System;
using System.Windows.Input;

namespace DewUserControls.Common
{
    /// <summary>
    /// Command class
    /// </summary>
    public class Command : ICommand
    {
        /// <summary>
        /// Can execute event change
        /// </summary>
        public event EventHandler CanExecuteChanged;
        /// <summary>
        /// Execute action
        /// </summary>
        private readonly Action execute;
        /// <summary>
        /// Can execute event
        /// </summary>  
        private readonly Func<bool> canExecute;
        /// <summary>
        /// Command execution
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canexecute"></param>
        public Command(Action execute, Func<bool> canexecute = null)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }
            this.execute = execute;
            this.canExecute = canexecute ?? (() => true);
        }
        /// <summary>
        /// Execute can execute if setted
        /// </summary>
        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
        /// <summary>
        /// Can execute
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public bool CanExecute(object o)
        {
            return this.canExecute();
        }
        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="p"></param>
        public void Execute(object p)
        {
            if (!CanExecute(p))
            {
                return;
            }
            this.execute();
        }
    }
}

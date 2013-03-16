using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Diagnostics;

namespace ArmandoShop.ProvidersClient.ViewModel
{
    /// <summary>
    /// Class to execute commands from delegates..
    /// </summary>
    class DelegateCommand : ICommand
    {
        private readonly Action<object> executeOneParam;
        private readonly Action<object, object> executeTwoParams;

        #region ICommand Members

        public DelegateCommand(Action<object> executeOneParam)
        {
            this.executeOneParam = executeOneParam;
        }

        public DelegateCommand(Action<object, object> executeTwoParams)
        {
            this.executeTwoParams = executeTwoParams;
        }

        #endregion

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            executeOneParam(parameter);
        }

        public void Execute(object parameter, object parameter2)
        {
            executeTwoParams(parameter, parameter2);
        }

        #endregion
    }
}

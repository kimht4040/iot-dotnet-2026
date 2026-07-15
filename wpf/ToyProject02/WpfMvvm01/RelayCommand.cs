using System;
using System.Windows.Input;

namespace WpfMvvm01
{
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;

        public RelayCommand(Action execute)
        {
            _execute = execute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true; // 항상 버튼을 누를 수 있도록 설정
        }

        public void Execute(object parameter)
        {
            _execute();
        }
    }
}
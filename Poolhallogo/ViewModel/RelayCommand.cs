using System.Windows.Input;

namespace Poolhallogo.ViewModel
{
    internal class RelayCommand : ICommand
    {
        public RelayCommand(Action onShoot)
        {
            OnShoot = onShoot;
        }

        public Action OnShoot { get; }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}
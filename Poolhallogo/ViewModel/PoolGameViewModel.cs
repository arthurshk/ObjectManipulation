using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Poolhallogo.ViewModel
{
    public class PoolGameViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Ball> Balls { get; set; }
        public int Player1Score { get; set; }
        public int Player2Score { get; set; }
        public bool IsPlayer1Turn { get; set; }
        public ICommand ShootCommand { get; private set; }
        public PoolGameViewModel() 
        {
            Balls = new ObservableCollection<Ball>();
            ShootCommand = new RelayCommand(OnShoot);
        }
        private void OnShoot()
        {
            //shot logic add 
            RaisePropertyChanged(nameof(Balls));
            RaisePropertyChanged(nameof(Player1Score));
            RaisePropertyChanged(nameof(Player2Score));
            RaisePropertyChanged(nameof(IsPlayer1Turn));
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}

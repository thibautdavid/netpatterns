using System.Windows.Input;
using TestableModel;
using U2U.WPF.CommandPattern;

namespace WPF_OrderProcessing.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private ViewModel _current;

        public ViewModel Current
        {
            get { return _current; }
            set { _current = value; OnPropertyChanged();}
        }

        public ICommand ShowOrderCommand { get; set; }

        public MainViewModel()
        {
            _current = new MessageViewModel {Message = "Click on command"};
        }

        void ShowOrder()
        {
            this.Current = new OrderViewModel
            {
                Order = Order.GetCurrentOrder()
            };
        }

        protected override void InitCommands()
        {
            ShowOrderCommand = new RelayCommand("Show order", ShowOrder, CanShowOrder);
        }

        private bool CanShowOrder()
        {
            return !(_current is OrderViewModel);
        }
    }
}
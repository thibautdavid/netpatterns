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

        public MainViewModel()
        {
            _current = new MessageViewModel {Message = "Click on command"};
        }
    }
}
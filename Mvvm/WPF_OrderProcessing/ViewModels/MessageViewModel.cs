namespace WPF_OrderProcessing.ViewModels
{
    public class MessageViewModel : ViewModel
    {
        private string _message;

        public string Message
        {
            get { return _message; }
            set { _message = value; OnPropertyChanged();}
        }
    }
}

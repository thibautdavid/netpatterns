namespace TestableModel
{
    public class OrderLine : Entity
    {
        public int Id { get; set; }

        private bool _selected;
        private string _productName;
        private decimal _price;

        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; OnPropertyChanged(); }
        }

        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; OnPropertyChanged(); }
        }

        public decimal Price
        {
            get { return _price; }
            set { _price = value; OnPropertyChanged(); }
        }
    }
}
using System.Collections.ObjectModel;

namespace TestableModel
{
    public class Order : Entity
    {
        private OrderLines _orderLines = new OrderLines();
        private decimal _totalPrice;
        private decimal _totalSelectdPrice;

        public OrderLines OrderLines
        {
            get { return _orderLines; }
            set { _orderLines = value; OnPropertyChanged();}
        }

        public decimal TotalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; OnPropertyChanged();}
        }

        public decimal TotalSelectdPrice
        {
            get { return _totalSelectdPrice; }
            set { _totalSelectdPrice = value; OnPropertyChanged();}
        }

        public static Order GetCurrentOrder()
        {
            return new Order
            {
                OrderLines = new OrderLines
                {
                    new OrderLine {ProductName = "Microsoft", Price=2677, Selected = true}
                }
            };
        }
    }

    public class OrderLines : ObservableCollection<OrderLine> { }
}
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

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

        public Order()
        {
            OrderLines.Changed += UpdatrePrice;
        }

        void UpdatrePrice(object sender, EventArgs e)
        {
            TotalPrice = OrderLines.Sum(i => i.Price);
            TotalSelectdPrice = OrderLines.Where(i => i.Selected)
                .Sum(i => i.Price);
        }
    }

    public class DetailedObservableCollection<T> : ObservableCollection<T> where T:INotifyPropertyChanged
    {
        public event EventHandler Changed = delegate {};
        private readonly GuardObservableCollection<T>  guard;

        public DetailedObservableCollection()
        {
            //base.CollectionChanged += DetailedObservableCollection_Changed;
            guard = new GuardObservableCollection<T>(() => Changed(this, EventArgs.Empty));
            guard.Attach(this);
        }

        //void DetailedObservableCollection_Changed(object sender, EventArgs e)
        //{
        //    Changed.Invoke(this, EventArgs.Empty);
        //}

        class GuardObservableCollection<T2> where T2 : INotifyPropertyChanged
        {
            private Action Changed { get; set; }

            public GuardObservableCollection(Action changed)
            {
                Changed = changed;
            }

            public void Attach(ObservableCollection<T2> coll)
            {
                if (coll == null) throw new ArgumentNullException(nameof(coll));
                coll.CollectionChanged += RaiseCollectionChanged;
                AttachItems(coll);
            }

            private void AttachItems(ObservableCollection<T2> coll)
            {
                foreach (var item in coll)
                {
                    item.PropertyChanged += RaisePropertyChanged;
                }
            }

            private void RaisePropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                Changed();
            }

            public void Detach(ObservableCollection<T2> coll)
            {
                if (coll == null) throw new ArgumentNullException(nameof(coll));
                coll.CollectionChanged -= RaiseCollectionChanged;
                DetachItems(coll);
            }

            private void DetachItems(ObservableCollection<T2> coll)
            {
                foreach (var item in coll)
                {
                    item.PropertyChanged -= RaisePropertyChanged;
                }
            }

            private void RaiseCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                if (e.OldItems != null) DetachItems((ObservableCollection<T2>)sender);
                if (e.NewItems!= null) AttachItems((ObservableCollection<T2>)sender);
                Changed();
            }
        }
    }

    public class OrderLines : DetailedObservableCollection<OrderLine> { }
}
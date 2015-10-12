namespace UnitTestProject1
{
  public class Order : Entity
  {
    #region Static method(s) to retrieve orders from storage
    public static Order GetCurrentOrder()
    {
      Order order = new Order();
      order.OrderLines.Add(new OrderLine { ProductName = "Apple", Price = 1, Selected = true });
      return order;
    }
    #endregion

    public Order()
    {
      orderLines = new OrderLines();
    }

    private decimal totalPrice;

    public decimal TotalPrice
    {
      get { return totalPrice; }
      set
      {
        if (totalPrice != value)
        {
          totalPrice = value;
          OnPropertyChanged();
        }
      }
    }

    private decimal totalSelectedPrice;

    public decimal TotalSelectedPrice
    {
      get { return totalSelectedPrice; }
      set
      {
        if (totalSelectedPrice != value)
        {
          totalSelectedPrice = value;
          OnPropertyChanged();
        }
      }
    }

    private OrderLines orderLines;

    public OrderLines OrderLines
    {
      get {
        return orderLines; 
      }
      set
      {
        orderLines = value;
        OnPropertyChanged();
      }
    }
  }
}

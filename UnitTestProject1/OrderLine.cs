namespace UnitTestProject1
{
  public class OrderLine : Entity
  {
    public int Id { get; set; }

    private bool selected;
    public bool Selected
    {
      get { return selected; }
      set
      {
        if (selected != value)
        {
          selected = value;
          OnPropertyChanged();
        }
      }
    }
    
    private string productName;
    public string ProductName
    {
      get { return productName; }
      set
      {
        if (productName != value)
        {
          productName = value;
          OnPropertyChanged();
        }
      }
    }

    
    private decimal price;
    public decimal Price
    {
      get { return price; }
      set
      {
        if (price != value)
        {
          price = value;
          OnPropertyChanged();
        }
      }
    }
  }
}

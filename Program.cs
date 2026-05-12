class Product
{
  private int id;
  private string name;
  private double price;
  private int remainingStock;
  private string category;

  public int Id
  {
    get { return id; }
    set { id = value; } 
  }

  public string Name
  {
    get { return name; }
    set { name = value; }
  }

  public double Price
  {
    get { return price; }
    set
    {
      if (value >= 0)
      { price = value; }
    }
  }

  public int RemainingStock
  {
    get { return remainingStock; }
    set
    {
      if (value >= 0)
      { remainingStock = value; }
    }
  }

  public string Category
  {
    get { return category; }
    set { category = value; }
  }

  public void DisplayProduct()
  {
    Console.WriteLine($"{Id}. {Name} - {Price} (Stock: {RemainingStock}) [{Category}]");
  }

  public bool HasEnoughStock(int qty)
  {
    return qty <= RemainingStock;
  }

  public void DeductStock(int qty)
  {
    RemainingStock -= qty;
  }
}

class CartItem
{
  private Product product;
  private int quantity;

  public Product product
  {
    get { return product; }
    set { product = value; }
  }

  public int Quantity
  {
    get { return quantity; }
    set
    {
      if (value > 0)
      { quantity = value; }
    }
  }

  public double GetSubtotal()
  {
    return Product.Price * Quantity;
  }
}

class Order
{
  private int receiptNumber;
  private double finalTotal;

  public int ReceiptNumber
  {
    get { return receiptNumber; }
    set { receiptNumber = value; }
  }

  public double FinanlTotal
  {
    get {return finalTotal; }
    set
    {
      if (value >=0)
      { finalTotal = value;}
    }
  }
}

class Program
{
  static void Main()
  {
    Product[] products =
    {
      new Product { Id = 1, Name = "Book", Price = 50, RemainingStock = 10, Category = "School Supplies"},
      new Product { Id = 2, Name = "Pentelpen", Price = 20, RemainingStock = 20, Category = "School Supplies"},
      new Product { Id = 3, Name = "Bag", Price = 50, RemainingStock = 10, Category = "School Supplies"},
    }
  }
}

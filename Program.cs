using System;
class Product
{
  public int Id;
  public string Name;
  public double Price;
  public int RemaningStock;

  piblic void DisplayProduct()
  {
    Console.WriteLine($"{Id}. {Name} - {Price} (Stock: {RemainingStock})");
  }

  public double GetItemTotal(int quantity)
  {
    return Price * quantity;
  }

  public bool HasEnoughStock(int quantity)
  {
    return quantity <= RemainingStock
  }
}

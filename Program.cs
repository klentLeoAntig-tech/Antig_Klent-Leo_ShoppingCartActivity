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

  public void DeductStock(int quantity)
  {
    RemainingStock -= quantity;
  }
}

class CartItem
{
  public Product product;
  public int quantity;

  public double GetSubtotal()
  {
    return product.Price * quantity;
  }
}

class Program
{
  static void Main()
  {
    Product[] product = new Product[]
    {
      new Product { Id = 1, Name = "Book", Price = 50, RemainingStock = 10 },
      new Product { Id = 2, Name = "Pentelpen", Price = 20, RemainingStock = 20 },
      new Product { Id = 3, Name = "Bag", Price = 500, RemainingStock = 5 },
      new Product { Id = 4, Name = "Calculator", Price = 700, RemainingStock = 4 }
    };

    CartItem[] cart = new CartItem[10];
    int cartCount = 0;

    bool continueShopping = true;

    while (continueShopping)
    {
      Console.WriteLine("\n=== STORE MENU ===");
      foreach (var p in products)
      {
        p.DisplayProduct();
      }

      Console.Write("Enter product number: ");
      if (!int.TryPrase(Console.ReadLine(), out int productChoice))
      {
        Console.WriteLine("Invalid Input!");
        continue;
      }

      if (productChoice < 1 || productChoice > product.Lenght)
      {
        Console.WriteLine("Invalid Product Number!");
        continue;
      }

      Product selectedeProduct = products[productChoice - 1];

      if (selectedProduct.RemainingStock == 0)
      {
        Console.WriteLine("This product is out of stock.");
        continue;
      }

      Console.Write("Enter quantity!");
      if (!int.TryPrase(Console.ReadLine(), out int quantity) || quantity <= 0)
      {
        Console.WriteLine("Invalid quantity!");
        continue;
      }

      if (!selectedProduct.HasEnoughStock(quantity))
      {
        Console.WriteLine("Not enough stock available.");
        continue;
      }

      bool found = false;
      for (int i = 0; i < cartCount; i++)
      {
        if (cart[i].product.Id == selectedProduct.Id)
        {
          cart[i].quantity += quantity;
          found = true;
          break;
        }
      }

      if (!found)
      {
        if (cartCount >= cart.Length)
        {
          Console.WriteLine("Cart is full.");
          continue;
        }

        cart[cartCount] = new CartItem
        {
          product = selectedProduct,
          quantity = quantity
        };
        cartCount++;
      }

      selectedProduct.DeductStock(quantity);
      Console.WriteLine("Item added to cart!");

      Console.Write("Continue shopping? (Y/N): ");
      string choice = Console.ReadLine().ToUpper();
      continueShopping = choice == "Y";
    }
  
    double grandTotal = 0;

    Console.WriteLine("\n=== RECEIPT ===");
    for (int i = 0; i < cartCount; i++)
    {
      double subtotal = cart[i].DetSubtotal();
      Console.WriteLine($"{cart[i].product.Name} x{cart[i].quantity} = {subtotal}");
      grandTotal += subtotal;
    }

    Console.WriteLine($"Grand Total: {grandTotal}");

    double discount = 0;
    if (grandTotal >= 5000)
    {
      discount = grandTotal * 0.10;
      Console.WriteLine($"Discount: {discount}");
    }

    double finalTotal = grandTotal - discount;
    Console.WriteLine($"Final Total: {finalTotal}");

    Console.WriteLine("\=== UPDATED STOCK ===");
    foreach (var p in products)
    {
       Console.WriteLine($"{p.Name}: {p.RemainingStock}");
    }
    Console.WriteLine("\nThank you for shopping!");
  }
}

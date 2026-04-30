using System;
class Product
{
  public int Id;
  public string Name;
  public double Price;
  public int RemainingStock;
  public string Category;

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
  public Product product;
  public int quantity;

  public double GetSubtotal()
  {
    return product.Price * quantity;
  }
}

Class Order
{
  public int ReceiptNumber;
  public double FinalTotal;
}
class Program
{
  static void Main()
  {
    Product[] product = 
    {
      new Product { Id = 1, Name = "Book", Price = 50, RemainingStock = 10, Category = "School Supplies"},
      new Product { Id = 2, Name = "Pentelpen", Price = 20, RemainingStock = 20, Category = "School Supplies"},
      new Product { Id = 3, Name = "Bag", Price = 500, RemainingStock = 5, Category = "School Supplies"},
      new Product { Id = 4, Name = "Mouse", Price = 500, RemainingStock = 10, Category = "Electronics"},
      new Product { Id = 5, Name = "Keyboard", Price = 700, RemainingStock = 4, Category = "Electronics"},
      new Product { Id = 6, Name = "Charger", Price = 100, RemainingStock = 10, Category = "Electronics"},
      new Product { Id = 7, Name = "Coke", Price = 20, RemainingStock = 10, Category = "Drinks"},
      new Product { Id = 8, Name = "Sprite", Price = 20, RemainingStock = 10, Category = "Drinks"},
      new Product { Id = 9, Name = "Royal", Price = 20, RemainingStock = 10, Category = "Drinks"},
    };

    CartItem[] cart = new CartItem[10];
    int cartCount = 0;

    Order[] history = new Order[10];
    int historyCount = 0;

    int recieptNumber = 1;

    bool running = true;

    while (running)
    {
      Console.WriteLine("\n=== AVAILABLE PRODUCTS ===");

      foreach (var p in products)
      {
        p.DisplayProduct();
      }

      Console.WriteLine("\n=== MAIN MENU ===");
      Console.WriteLine("1. Add Product to Cart");
      Console.WriteLine("2. Search Product");
      Console.WriteLine("3. Filter by Category");
      Console.WriteLine("4. View Cart");
      Console.WriteLine("5. Check Out");
      Console.WriteLine("6. Order History");
      Console.WriteLine("7. Exit");

      Console.Write("Choice: ");
      int choice;
      if (!int.TryParse(Console.ReadLine(), out choice))
      {
        Console.WriteLine("Invalid input");
        continue;
      }

      if (Choice == 1)
      {
        Console.WriteLine("Enter product ID: ");
        int id;

        if (!int.TryParse(Console.ReadLine(), out id))
        {
          Console.WriteLine("Invalid input!");
          continue;
        }

        if (id < 1 || id > products.Length)
        {
          Console.WriteLine("Product not found!");
          continue;
        }

        Product selected = products[id - 1];

        Console.Write("Enter quantity: ");
        int qty;

        if (!int.TryParse(Console.ReadLine(), out qty) || qty <= 0)
        {
          Console.WriteLine("Invalid quantity");
          continue;
        }

        if (!selected.HasEnoughStock(qty))
        {
          Console.WriteLine("Not enough stock");
          continue;
        }

        bool found = false;

        for (int i = 0; i < cartCount; i++)
        {
          if (cart[i].product.Id == selected.Id)
          {
            cart[i].quantity += qty;
            found = true;
          }
        }

        if (!found)
        {
          cart[cartCount] = new CartItem
          {
            product = selected,
            quantity = qty
          };
          cartCount++;
        }

        selected.DeductStock(qty);
        Console.WriteLine("Added to cart!");

        double currentTotal = 0;

        for (int i = 0; i < cartCount; i++)
        {
          currentTotal += cart[i].GetSubtotal();
        }
        
        Console.WriteLine($"Current Total: {currentTotal}"); 
      }

      else if (choice == 2)
      {
        Console.Write("Search: ");
        string search = Console.ReadLine().ToLower();

        foreach (var p in products)
        {
          if (p.Name.ToLower().Contains(search))
              p.DisplayProduct();
        }

        Console.Write("Enter product #: ");
        int index;
        if (!int.TryParse(Console.ReadLine(), out index))
            continue;

        if (index < 1 || index > productsLength)
            continue;

        Product seleted = products[index - 1];

        Console.Write("Quantity: "):
        int qty;
        if (!int.TryParse(Console.ReadLine(), out qty) || qty <= 0)
          continue;

        if (!selected.HasEnoughStock(qty))
        {
          Console.WriteLine("Not enough stock!");
          continue;
        }

        bool found = false;
        for (int i = 0; i < cartCount; i++)
        {
          if (cart[i].product.Id == selected.Id)
          {
            cart[i].quantity += qty;
            found = true;
          }
        }

        if (!found)
        {
          cart[cartCount] = new CartItem { product = selected, quantity = qty };
          cartCount++;
        }

        selected.DeductStock(qty);
        Console.WriteLine("Added to cart!");
      }
    }












      
      if (!selectedProduct

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
      double subtotal = cart[i].GetSubtotal();
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

    Console.WriteLine("\n=== UPDATED STOCK ===");
    foreach (var p in product)
    {
       Console.WriteLine($"{p.Name}: {p.RemainingStock}");
    }
    Console.WriteLine("\nThank you for shopping!");
  }


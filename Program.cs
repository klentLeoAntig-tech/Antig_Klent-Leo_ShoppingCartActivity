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
      else if (choice == 3)
      {
        Console.WriteLine("\n=== CATEGORIES ===");
        Console.WriteLine("1. Electronics");
        Console.WriteLine("2. School Supplies");
        Console.WriteLine("3. Drinks");
                
        Console.Write("Choose category: ");
        int catChoice;
        if (!int.TryParse(Console.ReadLine(), out catChoice))
        {
          Console.WriteLine("Invalid input!");
          continue;
        }
        string selectedCategory = "";
        
        if (catChoice == 1)
          selectedCategory = "Electronics";
        else if (catChoice == 2)
          selectedCategory = "School Supplies";
        else if (catChoice == 3)
          selectedCategory = "Drinks";
        else
        {
          Console.WriteLine("Invalid category!");
          continue;
        }
        
        Console.WriteLine("\nProducts in this category:");
        
        foreach (var p in products)
        {
          if (p.Category == selectedCategory)
              p.DisplayProduct();
        }
                
        // ADD TO CART FROM CATEGORY 
        Console.Write("Enter product #: ");
        int index;
        if (!int.TryParse(Console.ReadLine(), out index)) 
            continue;
                
        if (index < 1 || index > products.Length) 
            continue;
                
        Product selected = products[index - 1];
                
        Console.Write("Quantity: ");
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

      else if (choice == 4)
      {
        if (cartCount == 0)
        {
          Console.WriteLine("\nCart is empty");
          continue;
        }

        Console.WriteLine("\n=== YOUR CART ===");

        for (int i = 0; i < cartCount; i ++)
        {
          Console.WriteLine($"{i + 1}.{cart[i].product.Name} x{cart[i].quantity}");
        }
        Console.WriteLine("\n=== CART MENU ===");
        Console.WriteLine("1. Remove Item");
        Console.WriteLine("2. Update Quantity");
        Console.WriteLine("3. Clear Cart");
        Console.WriteLine("4. Back");

        Console.Write("Choice: ");
        int cartChoice;

        if (!int.TryParse(Console.ReadLine(), out cartChoice))
        {
          Console.WriteLine("Invalid input!");
          continue;
        }

        if (cartChoice == 1)
        {
          Console.Write("Enter item to remove: ");
          int removeIndex;

          if(int.TryParse(Console.ReadLine(), out removeIndex))
          {
            if (removeIndex >= 1 && removeIndex <= cartCount)
            {
              cart[removeIndex -1].product.RemainingStock += cart[removeIndex - 1].quantity;

              for (int i = removeIndex - 1; i < cartCount - 1; i++)
              {
                cart[i] = cart[i + 1];
              }
              cartCount--;
              Console.WriteLine("Item removed and stock returned!");
            }
          }
        }
        else if (cartChoice == 2)
        {
          Console.Write("Enter item number to update: ");
          int index;

          if (int.TryParse(Console.ReadLine(), out index))
          {
            if (index >= 1 && index <= cartCount)
            {
              CartItem item = cart[index - 1];

              Console.Write("Enter new quantity: ");
              int newQty;

              if (int.TryParse(Console.ReadLine(), out newQty) && newQty > 0)
              {
                int oldQty = item.quantity;

                item.product.RemainingStock += oldQty;

                if (!item.product.HasEnoughStock(newQty))
                {
                  Console.WriteLine("Not enough stock!");

                  item.product.RemainingStock -= oldQty;
                }
                else
                {
                  item.quantity = newQty;

                  item.product.DeductStock(newQty);

                  Console.WriteLine("Quantity updated");
                }
              }
            } 
          }
        }
        else if (cartChoice == 3)
        {
          for (int i = 0; i < cartCount; i++)
          {
            cart[i].product.RemainingStock += cart[i].quantity;
          }

          cartCount = 0;
          Console.WriteLine("Cart cleared and stock returned!");
        }

        else if (cartChoice == 4)
        {
          Console.WriteLine("Backing....");
        }
      }

      else if (choice == 5)
      {
        double total = 0;

        Console.WriteLine("\n=== YOUR ORDER ===");

        for (int i = 0; i , cartCount; i++)
        {
          double subtotal = cart[i].GetSubtotal();
          total = subtotal;

          Console.WriteLine($"{cart[i].product.Name} x{cart[i].quantitty} = {subtotal}");
        }

        double discount = (total >= 5000) ? total * 0.10 : 0;
        double finalTotal = total - discount;
        
        Console.WriteLine("\n YOUR TOTAL ");
        Console.WriteLine($"Total: {total}");
        Console.WriteLine($"Discount: {discount}");
        Console.WriteLine($"FINAL TOTAL: {finalTotal}");

        double payment;

        while (true)
        {
          Conssole.WriteLine("Enter payment: ");
          if (!double.TryParse(Console.ReadLine(), out payment))
          {
            Console.WriteLine("Invalid input");
            continue;
          }

          if (payment < finalTotal)
          {
            Cnosole.WriteLine("Insufficient payment!");
            continue;
          }
          break;
        }

        double change = payment - finalTotal;

        Console.WriteLine("\n=== RECIEPT ===");
        Console.WriteLine($"Reciept #: {recreiptNumber:D4}");
        Console.WriteLine($"Date: {DateTIme.Now}");

        Console.WriteLine($"Total: {total}");
        Console.WriteLine($"Discount: {discount}");
        Console.WriteLine($"Final total: {finalTotal}");

        Console.WriteLine($"Payment: {payment}");
        Console.WriteLine($"Change: {change}");

        history[historyCount] = new Order
        {
          RecieptNumber = recieptNumber,
          FinalTotal = finalTotal
        };

        historyCount++;
        recieptNumber++;

        Console.WriteLine("\nLOW STOCK ALERT:");
        foreach (var p in products)
        {
          if (p.RemainingStock <= 5)
              Console.WriteLine($"{p.Name} low stock: {p.RemainingStock}");
        }

        cartCount = 0;
      }

      else if (choice == 6)
      {
        Console.WriteLine("\n=== HISTORY ===");
        for (int i = 0; i < historyCount; i++)
        {
            Console.WriteLine($"Reciept #{history[i].ReciepNumber:D4} - {history[i].FinalTotal}");
        }
      }

      else if (choice == 7)
      {
        running = false;
        Console.WriteLine("\nTHANK YOU FOR PURCHASE!");
      }
    }
  }








      


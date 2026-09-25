using System.Collections.Generic;

public class Order
{
   private List<Product> _products = new List<Product>();
   private Customer _customer;

   public Order(Customer customer)
   {
       _customer = customer;
   }

   public void AddProduct(Product product)
   {
       _products.Add(product);
   }

   public double CalculateTotal()
   {
       double subtotal = 0;
       
       foreach (Product p in _products)
       {
           subtotal += p.GetTotalCost();
       }

       double shippingCost = 0;
       if (_customer.LivesInUSA())
       {
           shippingCost = 5.0;
       }
       else
       {
           shippingCost = 35.0;
       }

       return subtotal + shippingCost;
   }

   public string GetPackingLabel()
   {
       string label = "Packing Label:\n";
       foreach (Product p in _products)
       {
           label += $"- {p.GetName()} (ID: {p.GetProductId()})\n";
       }
       return label;
   }

   public string GetShippingLabel()
   {
       string label = "Shipping Label:\n";
       label += $"{_customer.GetName()}\n";
       label += _customer.GetAddress().GetAddressString();
       return label;
   }
}
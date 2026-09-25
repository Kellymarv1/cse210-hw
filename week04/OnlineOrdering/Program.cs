using System;

class Program
{
   static void Main(string[] args)
   {

       Console.WriteLine("Hello World! This is the OnlineOrdering Project.");

       Address address1 = new Address("123 Main St", "Rexburg", "ID", "USA");
       Address address2 = new Address("456 King St", "Toronto", "ON", "Canada");

       Customer customer1 = new Customer("John Smith", address1);
       Customer customer2 = new Customer("Jane Doe", address2);

       Product p1 = new Product("Laptop", "P100", 750.00, 1);
       Product p2 = new Product("Mouse", "P101", 20.00, 2);
       
       Product p3 = new Product("Keyboard", "P102", 45.00, 1);
       Product p4 = new Product("Monitor", "P103", 150.00, 1);

       Order order1 = new Order(customer1);
       order1.AddProduct(p1);
       order1.AddProduct(p2);

       Order order2 = new Order(customer2);
       order2.AddProduct(p3);
       order2.AddProduct(p4);

       Console.WriteLine(order1.GetPackingLabel());
       Console.WriteLine(order1.GetShippingLabel());
       Console.WriteLine($"Total Price: ${order1.CalculateTotal()}");
       Console.WriteLine("-----------------------------------");

       Console.WriteLine(order2.GetPackingLabel());
       Console.WriteLine(order2.GetShippingLabel());
       Console.WriteLine($"Total Price: ${order2.CalculateTotal()}");
       Console.WriteLine("-----------------------------------");
   }
}
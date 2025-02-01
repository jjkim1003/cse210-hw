using System;

class Program
{
    static void Main(string[] args)
    {
        // Creating customers
        Customer customer1 = new Customer("John Doe", new Address("123 Main St", "New York", "NY", "USA"));
        Customer customer2 = new Customer("Jane Smith", new Address("456 Maple Rd", "Toronto", "ON", "Canada"));

        // Creating orders
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "L123", 999.99, 1));
        order1.AddProduct(new Product("Mouse", "M456", 49.99, 2));

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Monitor", "MN789", 299.99, 1));
        order2.AddProduct(new Product("Keyboard", "KB101", 89.99, 1));

        // Displaying order details
        List<Order> orders = new List<Order> { order1, order2 };
        foreach (var order in orders)
        {
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order.GetTotalCost():F2}\n");
        }
    }
}

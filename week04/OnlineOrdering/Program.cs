using System;

class Program
{
    static void Main(string[] args)
    {
        // Order 1: customer in the USA (shipping $5)
        Address address1 = new Address("123 Maple Street", "Rexburg", "ID", "USA");
        Customer customer1 = new Customer("Sarah Johnson", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Notebook", "NB-101", 3.50, 4));
        order1.AddProduct(new Product("Pen Set", "PN-202", 6.25, 2));
        order1.AddProduct(new Product("Desk Lamp", "DL-303", 22.00, 1));

        // Order 2: customer outside the USA (shipping $35)
        Address address2 = new Address("45 Avenue Kasa-Vubu", "Mbujimayi", "Kasai-Oriental", "DR Congo");
        Customer customer2 = new Customer("Isaac Kabamba", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Backpack", "BP-404", 29.99, 1));
        order2.AddProduct(new Product("Water Bottle", "WB-505", 8.50, 3));

        DisplayOrder(order1);
        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order.GetTotalPrice():F2}");
        Console.WriteLine("--------------------------------");
        Console.WriteLine();
    }
}

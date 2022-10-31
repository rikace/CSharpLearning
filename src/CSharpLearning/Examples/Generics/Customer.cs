namespace Generic;

public class Customer
{
    public int ID { get; set; }
    public string Name { get; set; }
    
    
    
    public static void Run()
    {
        Dictionary<int, Customer> customers = new Dictionary<int, Customer>();
        Customer jane = new Customer { ID = 0, Name = "Jane" };
        Customer joe = new Customer { ID = 1, Name = "Joe" };
        customers.Add(jane.ID, jane);
        customers[joe.ID] = joe;

        foreach (int key in customers.Keys)
            Console.WriteLine(customers[key].Name);

        Dictionary<int, Customer> customers2 = new Dictionary<int, Customer>
        {
            [0] = new Customer { ID = 0, Name = "Chris" },
            [1] = new Customer { ID = 1, Name = "Alex" }
        };

        Console.ReadKey();
    }
}
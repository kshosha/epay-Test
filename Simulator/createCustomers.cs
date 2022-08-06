using System;
using System.Collections.Generic;
using System.Text;

namespace Simulator
{
    public class Customer
    {
        public int Id { set; get; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
    }

    public class createCustomers
    {
        string[] fNames = new string[] { "Leia", "Sadie", "Jose", "Sara", "Frank", "Dewey", "Tomas", "Joel", "Lukas", "Carlos" };
        string[] lNames = new string[] { "Liberty", "Ray", "Harrison", "Ronan", "Drew", "Powell", "Larsen", "Chan", "Anderson", "Lane" };
        public Customer createRundumCustomer(int id)
        {
            Customer customer = new Customer();
            Random myObject = new Random();
            customer.Id = id;
            customer.FirstName = fNames[myObject.Next(0, 9)];
            customer.LastName = lNames[myObject.Next(0, 9)];
            customer.Age = myObject.Next(10, 90);
            return customer;
        }

        public void createcustomers()
        {
            int baseID = 10;
            Random myObject = new Random();
            int count = myObject.Next(2, 6);
            Customer[] customers = new Customer[count];
            for (int i = 0; i < count; i++)
            {
                customers[i] = createRundumCustomer(baseID + i);
            }
            var r = Client.CreatecustomerAsync(customers).Result;
        }
    }
}

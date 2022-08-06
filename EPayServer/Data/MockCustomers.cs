using EPayServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Extensions.Options;

namespace EPayServer.Data
{
    public class MockCustomers : ICustomersRepo
    {
        private readonly IOptions<FilePath> options;
        private IList<Customer> customers;
        

        public MockCustomers(IOptions<FilePath> options)
        {
            this.options = options;
            Load();
        }

        public void CreateCustmer(Customer customer)
        {
            int index = customers.Count;
            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].LastName.CompareTo(customer.LastName) == 0)
                {
                    if (customers[i].FirstName.CompareTo(customer.FirstName) >= 0)
                    {
                        index = i;
                        break;
                    }
                }
                else if (customers[i].LastName.CompareTo(customer.LastName) > 0)
                {
                    index = i;
                    break;
                }
            }
            customers.Insert(index, customer);
            SaveChanges();
        }

        public Customer GetCustomerByID(int id)
        {
            return customers.FirstOrDefault(p => p.Id == id);
        }

        public void Load()
        {
            if (File.Exists(options.Value.path))
            {
                Stream s = File.Open(options.Value.path, FileMode.Open);
                BinaryFormatter b = new BinaryFormatter();
                customers = (IList<Customer>)b.Deserialize(s);
                s.Close();
            }
            else
            {
                customers = new List<Customer>();
                CreateCustmer(new Customer() { Id = 1, LastName = "Cccc", FirstName = "Bbbb", Age = 50 });
                CreateCustmer(new Customer() { Id = 2, LastName = "Aaaa", FirstName = "Bbbb", Age = 36 });
                CreateCustmer(new Customer() { Id = 3, LastName = "Aaaa", FirstName = "Aaaa", Age = 20 });
                CreateCustmer(new Customer() { Id = 4, LastName = "Dddd", FirstName = "Aaaa", Age = 70 });
                CreateCustmer(new Customer() { Id = 5, LastName = "Cccc", FirstName = "Aaaa", Age = 50 });
            }
            
        }

        public void SaveChanges()
        {
            StreamWriter f = new StreamWriter(options.Value.path);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(f.BaseStream, customers);
            f.Close();
        }

        Customer[] ICustomersRepo.GetCustomers()
        {
            return customers.ToArray();
        }
    }
}

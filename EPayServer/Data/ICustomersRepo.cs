using EPayServer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPayServer.Data
{
    public interface ICustomersRepo
    {
        public Customer[] GetCustomers();
        public Customer GetCustomerByID(int id);

        public void CreateCustmer(Customer customer);

        public void SaveChanges();

        public void Load();

        
    }
}

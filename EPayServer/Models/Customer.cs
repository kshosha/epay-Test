using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPayServer.Models
{
    [Serializable]
    public class Customer
    {
        public int Id { set; get; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
    }
}

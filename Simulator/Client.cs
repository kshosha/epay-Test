using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Simulator
{

    

    public class Client

    {
        static HttpClient client = new HttpClient();


        public static async Task<Uri> CreatecustomerAsync(Customer[] customer)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "http://localhost/EPayServer/Customers", customer);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }
    }
}


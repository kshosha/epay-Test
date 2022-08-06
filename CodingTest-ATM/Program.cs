using CodingTest_ATM.Controllers;
using System;
using System.ComponentModel;
using CodingTest_ATM.Models;

namespace CodingTest_ATM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AvailablePayoutController availablePayoutController = new AvailablePayoutController();
            var list = availablePayoutController.getAllPayoutOptions(370);
            foreach (var option in list)
            {
                string strOption = "";
                foreach(var payment in option.PayoutOptions)
                { 
                    if (strOption.Length>0)
                        strOption = strOption + " + ";
                    strOption += payment.Value + " x " + (int)((Denomination)payment.Key) + " EUR";
                }
                Console.WriteLine(strOption);
            }
        }
    }
}

using CodingTest_ATM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingTest_ATM.Data
{
    public class PayoutOption
    {
        public Dictionary<Denomination, int> PayoutOptions;
        public void addPayoutOption(Denomination denomination, int value)
        {
            if (PayoutOptions == null)
                PayoutOptions = new Dictionary<Denomination, int>();
            if (PayoutOptions.ContainsKey(denomination))
                PayoutOptions[denomination] = value;
            else
                PayoutOptions.Add(denomination, value);
        }
    }
}
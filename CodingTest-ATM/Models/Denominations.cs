using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CodingTest_ATM.Models
{
    
    public enum Denomination : ushort
    {
        [Description("10 EUR")]
        EUR10 = 10,
        [Description("50 EUR")]
        EUR50 = 50,
        [Description("100 EUR")]
        EUR100 = 100
    };
}

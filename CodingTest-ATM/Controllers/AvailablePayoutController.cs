using System;
using System.Collections.Generic;
using System.Text;
using CodingTest_ATM.Data;
using CodingTest_ATM.Models;

namespace CodingTest_ATM.Controllers
{
    internal class AvailablePayoutController
    {
        public IList<PayoutOption> getAllPayoutOptions(int N)
        {
            if (N == 0) return null;
            IList<PayoutOption> payoutOptions = new List<PayoutOption>();
            int count = N / 10;

            calculation(payoutOptions, count, 0, 0);
            return payoutOptions;

        }

        private void calculation(IList<PayoutOption> list, int T, int F, int H)
        {
            if (T >= 5)
                calculation(list, T - 5, F + 1, H);

            if (T >= 10)
                calculation(list, T - 10, F, H + 1);
            PayoutOption payoutOption = new PayoutOption();
            if (T > 0)
                payoutOption.addPayoutOption(Denomination.EUR10, T);
            if (F > 0)
                payoutOption.addPayoutOption(Denomination.EUR50, F);
            if (H > 0)
                payoutOption.addPayoutOption(Denomination.EUR100, H);
            list.Add(payoutOption);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Initial
{
    class ProductLine
    {
        const double minAmountForBatchDiscount = 10;

        double basePrice;
        double amount;
        bool useVat;

        public ProductLine(double basePrice, double amount, bool useVat)
        {
            this.basePrice = basePrice;
            this.amount = amount;
            this.useVat = useVat;
        }

        public double GetPrice()
        {
            double price = basePrice * amount;
            if (useVat)
                price = price * 1.27;

            if (amount >= minAmountForBatchDiscount)
                price = 0.9 * price;

            return price;
        }
    }
}

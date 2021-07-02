using System;

namespace Library
{
    public class CurrencyChanger
    {
        public double dollar = 45.5;

        public double MoneyChanger(double productCost)
        {
            return productCost*dollar;
        }
    }
}
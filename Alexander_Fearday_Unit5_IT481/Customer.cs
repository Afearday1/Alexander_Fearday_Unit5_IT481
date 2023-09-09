using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alexander_Fearday_Unit5_IT481
{
    class Customer
    {
        int numberOfItems = 6;

        public Customer() 
        {
            numberOfItems = 6;
        }

        public Customer(int items)
        {
            int clothingItems = items;

            if (clothingItems == 0)
            {
                numberOfItems = GetRandomNumber(1, 20);
            }
            else
            {
                numberOfItems = clothingItems;
            }
        }
        public int getNumberOfItems()
        {
            return numberOfItems;
        }

        private static readonly Random getrandom = new Random();

        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom)
            {
                return getrandom.Next(min, max);
            }
        }

    }
}

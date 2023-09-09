using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alexander_Fearday_Unit5_IT481
{
    class Scenario
    {
        static Customer cust;
        static int items = 0;
        static int numberOfItems;
        static int controlItemNumber;

        public Scenario(int r, int c)
        {
            Console.WriteLine(r + " dressing rooms " + " for " + c + " customers.");

            controlItemNumber = 0;
            numberOfItems = 0;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("What ClothItem value do you want? (0 = random)");
            controlItemNumber = Int32.Parse(Console.ReadLine());

            Console.WriteLine("How many customers do you want? ");
            int numberOfCustomers = Int32.Parse(Console.ReadLine());

            Console.WriteLine("How many dressing rooms do you want? ");
            int totalRooms = Int32.Parse(Console.ReadLine());

            Scenario s = new Scenario(totalRooms, numberOfCustomers);

            DressingRoom dr = new DressingRoom(totalRooms);

            List<Task> tasks = new List<Task>();

            for (int i = 0; i < numberOfCustomers; i++)
            {
                cust = new Customer(controlItemNumber);

                numberOfItems = cust.getNumberOfItems();

                items += numberOfItems;

                tasks.Add(Task.Factory.StartNew(async () =>
                {
                    await dr.RequestRoom(cust);
                }));
            }
            
            Task.WaitAll(tasks.ToArray());

            Console.WriteLine("Average Run Time in milliseconds {0} ", dr.getRunTime() / numberOfCustomers);
            Console.WriteLine("Average Wait Time in milliseconds {0} ", dr.getWaitTime() / numberOfCustomers);
            Console.WriteLine("Total customers is {0}", numberOfCustomers);
            int averageItemsPerCustomer = items / numberOfCustomers;

            Console.WriteLine("Average number of items was: " + averageItemsPerCustomer);
            Console.Read();
        }
    }
}

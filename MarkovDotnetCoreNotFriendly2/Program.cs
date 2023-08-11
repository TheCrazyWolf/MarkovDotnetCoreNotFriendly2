using MarkovDotnetCoreNotFriendly2.Saver;
using MarkovSharp.TokenisationStrategies;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkovDotnetCoreNotFriendly2
{
    internal class Program
    {
        private static Manager _manager = new Manager();

        static void Main(string[] args)
        {
            //_manager.OnLoadDataFirst();
            //return;

            // Create a new model
            var model = new StringMarkov(1);

            // Train the model
            model.Learn(_manager.OnLoadData());

            int i = 0;
            // Output:
            // Frankly, my dear, I don't give a box of their possessions.
            while (true)
            {
                i++;

                //var sentense_new = model.Walk(3).ToArray();
                //string sentense_new_string = sentense_new[0] + sentense_new[1] + sentense_new[2];
                //Console.WriteLine($"{i}) {sentense_new_string}");

                var sentense_new = model.Walk().ToArray();
                string sentense_new_string = sentense_new[0];
                Console.WriteLine($"{i}) {sentense_new_string}");

                //model.Learn(sentense_new_string);

                //_manager.PutData(sentense_new_string);
            }

        }
    }
}

using Codecool.SixHandshakes.Model;
using System;
using System.Collections.Generic;
using Codecool.SixHandshakes.Finders;
using System.Linq;

namespace Codecool.SixHandshakes
{
    /// <summary>
    /// This is the main class of your program which contains Main method
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            List<UserNode> Nodes = RandomDataGenerator.Generate();
            Console.WriteLine(HandshakeCalculator.GetMinimumHandshakesBetween(Nodes[0], Nodes[42]));
            Console.ReadLine();

            //Display.Display.Menu();
        }
    }
}

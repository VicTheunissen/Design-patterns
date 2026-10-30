using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory
{
    internal abstract class Pizza
    {
        internal void Bake()
        {
            Console.WriteLine("Baking the pizza");
        }

        internal void Box()
        {
            Console.WriteLine("Boxing the pizza");
        }

        internal void Cut()
        {
            Console.WriteLine("Cutting the pizza into squares");
        }

        internal void Prepare()
        {
            Console.WriteLine("Preparing the pizza");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory
{
    internal class SimplePizzaFactory
    {
        public virtual Pizza CreatePizza(string type)
        {
            Pizza pizza = null;

            if(type.Equals("cheese"))
            {
                pizza = new CheesePizza();
            }
            else if (type.Equals("pepperoni"))
            {
                pizza = new PepperoniPizza();
            }
            else if (type.Equals("clam"))
            {
                pizza = new ClamPizza();
            }
            else if (type.Equals("veggie"))
            {
                pizza = new VeggiePizza();
            }

            return pizza;
        }
    }
}

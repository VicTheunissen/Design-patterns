using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern.Interfaces
{
    internal class GooseAdapter : Duck
    {
        private Goose goose;
        public GooseAdapter(Goose goose)
        {
            this.goose = goose;
        }
        public void Quack()
        {
            goose.Honk();
        }

        public void Fly()
        {
            goose.Fly();
        }
    }
}

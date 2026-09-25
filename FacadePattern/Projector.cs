using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern
{
    internal class Projector
    {
        private DvdPlayer? _dvdPlayer;
        public Projector()
        {
        }

        public void SetInput(DvdPlayer dvdPlayer)
        {
            this._dvdPlayer = dvdPlayer;
            Console.WriteLine("Projector: input set to DVD player");
        }

        public void On()
        {
            Console.WriteLine("Projector: On");
        }

        public void Off()
        {
            Console.WriteLine("Projector: Off");
        }

        public void TvMode()
        {
            Console.WriteLine("Projector: TV mode (4x3 aspect ratio)");
        }

        public void WideScreenMode()
        {
            Console.WriteLine("Projector: widescreen mode (16x9 aspect ratio)");
        }
    }
}

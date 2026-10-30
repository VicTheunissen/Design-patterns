namespace SingletonPattern
{
    internal class ChocolateBoiler
    {
        private static ChocolateBoiler? _instance;
        private static readonly object _lock = new object();

        private bool empty;
        private bool boiled;

        public bool IsEmpty { get { return this.empty; } }
        public bool IsBoiled { get { return this.boiled; } }

        private ChocolateBoiler()
        {
            empty = true;
            boiled = false;
        }

        public static ChocolateBoiler GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new ChocolateBoiler();
                    }
                }
            }
            return _instance;
        }

        public void Fill()
        {
            if (empty)
            {
                empty = false;
                boiled = false;
                Console.WriteLine("Filling the boiler with a milk/chocolate mixture.");
            }
        }

        public void Drain()
        {
            if (!empty && boiled)
            {
                empty = true;
                Console.WriteLine("Draining the boiled milk and chocolate.");
            }
        }

        public void Boil()
        {
            if (!empty && !boiled)
            {
                boiled = true;
                Console.WriteLine("Bringing the contents to a boil.");
            }
        }
    }
}

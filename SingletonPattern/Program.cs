namespace SingletonPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Singleton ChocolateBoiler Demo ===\n");

            // Demonstreer dat meerdere threads dezelfde instance krijgen
            Console.WriteLine("Starting 5 threads that each request the ChocolateBoiler instance...\n");

            var tasks = new Task<ChocolateBoiler>[5];
            for (int i = 0; i < tasks.Length; i++)
            {
                int threadNum = i + 1;
                tasks[i] = Task.Run(() =>
                {
                    var boiler = ChocolateBoiler.GetInstance();
                    Console.WriteLine($"Thread {threadNum}: Got instance #{boiler.GetHashCode()}");
                    return boiler;
                });
            }

            Task.WaitAll(tasks);

            // Controleer dat alle threads dezelfde instance kregen
            bool allSame = tasks.All(t => t.Result.GetHashCode() == tasks[0].Result.GetHashCode());
            Console.WriteLine($"\nAll threads received the same instance: {allSame}\n");

            // Gebruik de singleton
            Console.WriteLine("=== Using the ChocolateBoiler ===\n");
            var chocolateBoiler = ChocolateBoiler.GetInstance();
            chocolateBoiler.Fill();
            chocolateBoiler.Boil();
            chocolateBoiler.Drain();
        }
    }
}

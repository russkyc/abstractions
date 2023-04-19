using System;
using System.Threading;
using Russkyc.Abstractions.Abstractions;

namespace AbstractionsTest
{
    static class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World!");
            var p1 = Person.Instance;
            var p2 = Person.Instance;
            var p3 = Person.Instance;
            p1.Name = "Test Singleton";
            p2.Info = "Singleton Instance";
            new Thread(
                _ =>
                {
                    p3.Name = "Threaded";
                }).Start();
            new Thread(
                _ =>
                {
                    p3.Info = "Shared Instance Thread";
                    Console.WriteLine($"{p3.Name}, {p3.Info}");
                }).Start();
            Console.WriteLine($"{p1.Name}, {p1.Info}");
            Console.WriteLine($"{p2.Name}, {p2.Info}");
            Console.WriteLine($"{p3.Name}, {p3.Info}");
        }
    }
}

class Person : Shared<Person>
{
    public string Name { get; set; }
    public string Info { get; set; }
}
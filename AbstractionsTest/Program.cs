using System;
using System.Collections.Generic;
using System.Linq;
using Russkyc.Abstractions.Interfaces;

namespace AbstractionsTest
{
    static class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(TestRepo.Instance.GetCollection().Count);
            TestRepo.Instance.Insert(
                new Person
                {
                    Name = "Russell",
                    Info = "Russkyc"
                });
            TestRepo.Instance.Insert(
                new Person
                {
                    Name = "Russell",
                    Info = "Russky42"
                });
            TestRepo.Instance.Insert(
                new Person
                {
                    Name = "Cronica",
                    Info = "Cronicles"
                });
            
            TestRepo.Instance.GetCollection().ToList().ForEach( p => Console.WriteLine($"{p.Name}, {p.Info}"));
            TestRepo.Instance.Update(p => p.Name.Contains("Russell"), p => p.Name = "Test");
            Console.WriteLine(TestRepo.Instance.GetCollection().Count);
            TestRepo.Instance.Delete(p => p.Name.Contains("e"));
            Console.WriteLine(TestRepo.Instance.GetCollection().Count);
            TestRepo.Instance.GetCollection().ToList().ForEach( p => Console.WriteLine($"{p.Name}, {p.Info}"));
        }
    }
}

class TestRepo : IRepository<Person>
{
    private static object _lock;
    private static IRepository<Person> _instance;
    private IList<Person> _persons;

    public TestRepo()
    {
        _lock = new object();
        _persons = new List<Person>();
    }

    public bool Insert(Person item)
    {
        _persons.Add(item);
        return _persons.Contains(item);
    }
    
    public bool Insert(ICollection<Person> items)
    {
        items.ToList().ForEach(_persons.Add);
        return true;
    }

    public Person Get(Func<Person, bool> filter)
    {
        return _persons.Where(filter).First();
    }

    public ICollection<Person> GetAll(Func<Person, bool> filter)
    {
        return _persons.Where(filter).ToList();
    }

    public ICollection<Person> GetCollection()
    {
        return _persons;
    }
    
    public bool Update(Func<Person, bool> filter, Action<Person> action)
    {
        _persons.Where(filter).ToList().ForEach(action);
        return true;
    }

    public bool Delete(Func<Person, bool> filter)
    {
        _persons.Where(filter).ToList().ForEach(entity => _persons.Remove(entity));
        return true;
    }

    public static IRepository<Person> Instance
    {
        get
        {
            if (_instance is null)
            {
                lock (_lock)
                {
                    if (_instance is null)
                    {
                        _instance = new TestRepo();
                    }
                }
            }

            return _instance;
        }
    }
}

class Person
{
    public string Name { get; set; }
    public string Info { get; set; }
}
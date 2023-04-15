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
            TestRepo t = new TestRepo();

            Console.WriteLine(t.GetCollection().Count);
            t.Insert(
                new Person
                {
                    Name = "Russell",
                    Info = "Russkyc"
                });
            t.Insert(
                new Person
                {
                    Name = "Russell",
                    Info = "Russky42"
                });
            t.Insert(
                new Person
                {
                    Name = "Cronica",
                    Info = "Cronicles"
                });
            
            t.GetCollection().ToList().ForEach( p => Console.WriteLine($"{p.Name}, {p.Info}"));
            t.Update(p => p.Name.Contains("Russell"), p => p.Name = "Test");
            Console.WriteLine(t.GetCollection().Count);
            t.Delete(p => p.Name.Contains("e"));
            Console.WriteLine(t.GetCollection().Count);
            t.GetCollection().ToList().ForEach( p => Console.WriteLine($"{p.Name}, {p.Info}"));
        }
    }
}

class TestRepo : IRepository<Person>
{
    private IList<Person> _persons;

    public TestRepo()
    {
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

    public IRepository<Person> GetInstance()
    {
        throw new NotImplementedException();
    }
}

class Person
{
    public string Name { get; set; }
    public string Info { get; set; }
}
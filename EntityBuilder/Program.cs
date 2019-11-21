using System;
using System.Collections.Generic;
using EntityBuilder.Blas;

namespace EntityBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new BlaBuilder();

            var events = new List<object>();
            events.Add(new AddFoo(3));
            events.Add(new AddBar(1));
            events.Add(new AddFoo(2));

            var bla = builder.Apply(Bla.Empty, events);

            Console.WriteLine($"Foo: {bla.Foo}");
            Console.WriteLine($"Bar: {bla.Bar}");
        }
    }
}

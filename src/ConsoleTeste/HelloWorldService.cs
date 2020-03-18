using System;
using Volo.Abp.DependencyInjection;

namespace ConsoleTeste
{
    public class HelloWorldService : ITransientDependency
    {
        public void SayHello()
        {
            Console.WriteLine("Hello World!");
        }
    }
}
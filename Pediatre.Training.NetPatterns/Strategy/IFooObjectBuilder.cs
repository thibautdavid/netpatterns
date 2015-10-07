using System;
using System.Collections.Generic;
using System.Linq;

namespace Pediatre.Training.NetPatterns.Strategy
{
    interface IFooObjectBuilder
    {
        IFoo Build(CreationInfo creationInfo);
    }

    internal class ConfigFooBuilder : IFooObjectBuilder
    {
        public IFoo Build(CreationInfo creationInfo)
        {
            return null;
        }
    }

    internal class FromAssemblyFooBuilder : IFooObjectBuilder
    {
        public IFoo Build(CreationInfo creationInfo)
        {
            var type = GetType().Assembly.GetTypes().SingleOrDefault(t => t.FullName == creationInfo.Name);
            if (type != null)
            {
                creationInfo.FooInstance = Activator.CreateInstance(type) as IFoo;
            }
            
            return creationInfo.FooInstance;
        }
    }

    internal class AddLoggingToFooBuilder : IFooObjectBuilder
    {
        public IFoo Build(CreationInfo creationInfo)
        {
            Console.Out.WriteLine($"Pass in Build of builder: {GetType().FullName}");
            return creationInfo.FooInstance;
        }
    }
    internal class CreationInfo
    {
        public IFoo FooInstance { get; set; }
        public string Name { get; set; }
    }

    public sealed class ObjectFactory
    {
        private readonly IList<IFooObjectBuilder> _strategies =
            new List<IFooObjectBuilder>{
                new ConfigFooBuilder(), new FromAssemblyFooBuilder()
            };

        internal IFoo Create(CreationInfo creationInfo)
        {
            IFoo fooInstance = null;
            foreach (var fooObjectBuilder in _strategies)
            {
                fooInstance = fooObjectBuilder.Build(creationInfo);
                if (fooInstance != null)
                    break;
            }

            return fooInstance;
        }
    }

    /// <summary>
    /// Create a Foo instance and add a log decorator
    /// </summary>
    public sealed class VerboseObjectFactory
    {
        private readonly IList<IFooObjectBuilder> _strategies =
            new List<IFooObjectBuilder>{
                new ConfigFooBuilder(), new FromAssemblyFooBuilder()
            };
        
        internal IFoo Create(CreationInfo creationInfo)
        {
            var fooBuilderWithLog = new AddLoggingToFooBuilder();
            foreach (var fooObjectBuilder in _strategies)
            {
                creationInfo.FooInstance = fooObjectBuilder.Build(creationInfo);
                if (creationInfo.FooInstance != null)
                    break;
            }

            return fooBuilderWithLog.Build(creationInfo);
        }
    }

}

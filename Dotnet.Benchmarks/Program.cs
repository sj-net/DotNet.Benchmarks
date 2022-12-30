using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using Bogus;
using System.Dynamic;

namespace Dotnet.Benchmarks
{
    internal class Program
    {

        static void Main(string[] args)
        {
#if !DEBUG
            BenchmarkRunner.Run<SystemTextJsonVsMessagePack>();
#else 

            var t = new Serialization().Json().Result;
#endif
        }
    }
}
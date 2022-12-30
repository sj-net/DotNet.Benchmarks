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
            //BenchmarkRunner.Run<SystemTextJsonVsMessagePack>();
            BenchmarkRunner.Run<SerialzationAndDeserialization>();
#else 

            var t = new SerialzationAndDeserialization().MessagePackSerialize();
#endif
        }
    }
}
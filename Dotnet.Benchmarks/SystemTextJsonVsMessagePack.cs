using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Dotnet.Benchmarks
{
    [MemoryDiagnoser]
    [ThreadingDiagnoser]
    [CsvExporter, HtmlExporter]
    //[SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net60, iterationCount: 5)]
    [SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net60, iterationCount: 5)]
    [MinColumn, MaxColumn, MeanColumn, MedianColumn]
    //[HardwareCounters]
    //[EventPipeProfiler(BenchmarkDotNet.Diagnosers.EventPipeProfile.CpuSampling)]
    //[DisassemblyDiagnoser]
    public class SystemTextJsonVsMessagePack
    {
        HttpClientHandler handler => new HttpClientHandler()
        {
            AutomaticDecompression = DecompressionMethods.Brotli | DecompressionMethods.GZip | DecompressionMethods.Deflate | DecompressionMethods.None
        };

        // Note : Protobuf doesn't support expando object.
        // Note : ZeroFormatter doesn't support expando object.
        // Note : MemoryPack also isn't working with expando object.
        // Notes:
        // 1. Different compression algorithms are not helping much.

        [Benchmark(Baseline = true)]
        public async Task<List<ExpandoObject>> Json()
        {
            using (var httpClient = new HttpClient(handler) { BaseAddress = new Uri("http://localhost:5065") })
            {
                var response = await httpClient.GetAsync("/api/benchmarks/Serialzation/GetExpando");
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<ExpandoObject>>(content);

            }
        }

        [Benchmark]
        public async Task<List<ExpandoObject>> MessagePack()
        {
            using (var httpClient = new HttpClient(handler) { BaseAddress = new Uri("http://localhost:5065") })
            {
                httpClient.DefaultRequestHeaders.Add("Accept", "application/msgpack");
                var response = await httpClient.GetAsync("/api/benchmarks/Serialzation/GetExpando");
                var content = await response.Content.ReadAsByteArrayAsync();
                return global::MessagePack.MessagePackSerializer.Deserialize<List<ExpandoObject>>(content);
            }
        }

    }
}

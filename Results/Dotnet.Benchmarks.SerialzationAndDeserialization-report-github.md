``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 10 (10.0.19044.2364/21H2/November2021Update)
Intel Xeon W-10855M CPU 2.80GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 6.0.11 (6.0.1122.52304), X64 RyuJIT AVX2
  Job-OBHMHM : .NET 6.0.11 (6.0.1122.52304), X64 RyuJIT AVX2

Runtime=.NET 6.0  IterationCount=5  

```
|                           Method |       Mean |     Error |    StdDev |        Min |        Max |     Median |       Gen0 | Completed Work Items | Lock Contentions |       Gen1 | Allocated |
|--------------------------------- |-----------:|----------:|----------:|-----------:|-----------:|-----------:|-----------:|---------------------:|-----------------:|-----------:|----------:|
|   &#39;System.Text.Json - Serialize&#39; |   325.0 ms |  16.39 ms |   2.54 ms |   322.0 ms |   328.1 ms |   324.9 ms |   500.0000 |                    - |                - |          - | 106.47 MB |
|        &#39;MessagePack - Serialize&#39; |   188.0 ms |  20.86 ms |   5.42 ms |   179.0 ms |   193.2 ms |   188.5 ms |  5666.6667 |                    - |                - |  2000.0000 |  75.08 MB |
|           &#39;JSON.Net - Serialize&#39; |   449.8 ms |  26.58 ms |   6.90 ms |   443.8 ms |   460.1 ms |   447.2 ms | 28000.0000 |                    - |                - |  9000.0000 | 272.18 MB |
| &#39;System.Text.Json - Deserialize&#39; | 1,353.2 ms | 487.29 ms | 126.55 ms | 1,234.8 ms | 1,550.8 ms | 1,339.8 ms | 67000.0000 |                    - |                - | 23000.0000 | 455.72 MB |
|      &#39;MessagePack - Deserialize&#39; |   557.3 ms |  32.39 ms |   5.01 ms |   550.2 ms |   561.8 ms |   558.6 ms | 34000.0000 |                    - |                - |  9000.0000 | 209.55 MB |
|         &#39;JSON.Net - Deserialize&#39; |   789.7 ms |  12.59 ms |   3.27 ms |   786.3 ms |   794.4 ms |   789.2 ms | 37000.0000 |                    - |                - | 10000.0000 | 224.38 MB |

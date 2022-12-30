``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 10 (10.0.19044.2364/21H2/November2021Update)
Intel Xeon W-10855M CPU 2.80GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 6.0.11 (6.0.1122.52304), X64 RyuJIT AVX2
  Job-EDFSBA : .NET 6.0.11 (6.0.1122.52304), X64 RyuJIT AVX2

Runtime=.NET 6.0  IterationCount=5  

```
|      Method |       Mean |    Error |   StdDev |        Min |        Max |     Median | Ratio |       Gen0 | Completed Work Items | Lock Contentions |       Gen1 |      Gen2 | Allocated | Alloc Ratio |
|------------ |-----------:|---------:|---------:|-----------:|-----------:|-----------:|------:|-----------:|---------------------:|-----------------:|-----------:|----------:|----------:|------------:|
|        Json | 2,340.8 ms | 380.9 ms | 98.92 ms | 2,231.7 ms | 2,450.8 ms | 2,356.9 ms |  1.00 | 69000.0000 |            3462.0000 |                - | 25000.0000 | 2000.0000 | 686.17 MB |        1.00 |
| MessagePack |   944.4 ms | 133.3 ms | 20.62 ms |   928.5 ms |   972.6 ms |   938.3 ms |  0.40 | 37000.0000 |               8.0000 |                - | 11000.0000 | 2000.0000 |    375 MB |        0.55 |

using System;

namespace Dotnet.Benchmarks
{
    public class Foo
    {
        public Guid Guid { get; set; } = Guid.NewGuid();
        public int Integer { get; set; } = int.MaxValue;
        public string String { get; set; } = "some random string";
        public double Double { get; set; } = double.MaxValue;
        public decimal Decimal { get; set; } = decimal.MaxValue;
        public DateTime DateTime { get; set; } = DateTime.Now;
        public DateTimeOffset DateTimeOffset { get; set; } = new DateTimeOffset(DateTime.Now);

    }
}

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using System;
using System.Reflection;

namespace Dotnet.Benchmarks
{
    [HtmlExporter]
    [StatisticalTestColumn()]
    [SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net80)]
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory), CategoriesColumn, BaselineColumn]
    public class CostOfReflection
    {
        protected readonly Foo foo;
        protected readonly Bar bar;
        private DateTime dateTimeValue = DateTime.Now;
        public CostOfReflection()
        {
            foo = new Foo();
            bar = new Bar();
        }


        [Benchmark(Baseline = true), BenchmarkCategory("get_DateTime")]
        public void Refection_Get_DateTime() => foo.GetUsingReflection(nameof(Foo.DateTime));

        [Benchmark(), BenchmarkCategory("get_DateTime")]
        public void IObject_Get_DateTime() => bar.GetValue(nameof(Foo.DateTime));

        [Benchmark(Baseline = true), BenchmarkCategory("set_DateTime")]

        public void Reflection_Set_DateTime() => foo.SetUsingReflection(nameof(Foo.DateTime), dateTimeValue);

        [Benchmark(), BenchmarkCategory("set_DateTime")]
        public void IObject_Set_DateTime() => bar.SetValue(nameof(Foo.DateTime), dateTimeValue);


        [Benchmark(Baseline = true), BenchmarkCategory("get_Double")]
        public void Refection_Get_Double() => foo.GetUsingReflection(nameof(Foo.Double));

        [Benchmark(), BenchmarkCategory("get_Double")]
        public void IObject_Get_Double() => bar.GetValue(nameof(Foo.Double));

        [Benchmark(Baseline = true), BenchmarkCategory("set_Double")]

        public void Reflection_Set_Double() => foo.SetUsingReflection(nameof(Foo.Double), 10D);

        [Benchmark(), BenchmarkCategory("set_Double")]
        public void IObject_Set_Double() => bar.SetValue(nameof(Foo.Double), 10D);

        [Benchmark(Baseline = true), BenchmarkCategory("get_Decimal")]
        public void Refection_Get_Decimal() => foo.GetUsingReflection(nameof(Foo.Decimal));

        [Benchmark(), BenchmarkCategory("get_Decimal")]
        public void IObject_Get_Decimal() => bar.GetValue(nameof(Foo.Decimal));

        [Benchmark(Baseline = true), BenchmarkCategory("set_Decimal")]

        public void Reflection_Set_Decimal() => foo.SetUsingReflection(nameof(Foo.Decimal), 10M);

        [Benchmark(), BenchmarkCategory("set_Decimal")]
        public void IObject_Set_Decimal() => bar.SetValue(nameof(Foo.Decimal), 10.1M);

        [Benchmark(Baseline = true), BenchmarkCategory("get_String")]
        public void Refection_Get_String() => foo.GetUsingReflection(nameof(Foo.String));

        [Benchmark(), BenchmarkCategory("get_String")]
        public void IObject_Get_String() => bar.GetValue(nameof(Foo.String));

        [Benchmark(Baseline = true), BenchmarkCategory("set_String")]

        public void Reflection_Set_String() => foo.SetUsingReflection(nameof(Foo.String), "some string");

        [Benchmark(), BenchmarkCategory("set_String")]
        public void IObject_Set_String() => bar.SetValue(nameof(Foo.String), "some string");


        [Benchmark(Baseline = true), BenchmarkCategory("get_Integer")]
        public void Refection_Get_Integer() => foo.GetUsingReflection(nameof(Foo.Integer));

        [Benchmark(), BenchmarkCategory("get_Integer")]
        public void IObject_Get_Integer() => bar.GetValue(nameof(Foo.Integer));

        [Benchmark(Baseline = true), BenchmarkCategory("set_Integer")]

        public void Reflection_Set_Integer() => foo.SetUsingReflection(nameof(Foo.Integer), 10);

        [Benchmark(), BenchmarkCategory("set_Integer")]
        public void IObject_Set_Integer() => bar.SetValue(nameof(Foo.Integer), 10);
    }
}

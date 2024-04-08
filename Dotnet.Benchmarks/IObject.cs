namespace Dotnet.Benchmarks
{
    public interface IObject
    {
        bool SetValue(string propertyName, object value);

        object GetValue(string propertyName);
    }
}

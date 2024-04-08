using System;

namespace Dotnet.Benchmarks
{
    public class Bar : Foo, IObject
    {
        public object GetValue(string propertyName)
        {
            return propertyName switch
            {
                nameof(Integer) => Integer,
                nameof(String) => String,
                nameof(Double) => Double,
                nameof(Decimal) => Decimal,
                nameof(DateTime) => DateTime,
                nameof(DateTimeOffset) => DateTimeOffset,
                nameof(Guid) => Guid,
                _ => null,
            };
        }

        public bool SetValue(string propertyName, object value)
        {
            switch (propertyName)
            {
                case nameof(Integer):
                    {
                        Integer = (int)value;
                        return true;
                    }
                case nameof(String):
                    {
                        String = (string)value;
                        return true;
                    }
                case nameof(Double):
                    {
                        Double = (double)value;
                        return true;
                    }
                case nameof(Decimal):
                    {
                        Decimal = (decimal)value;
                        return true;
                    }
                case nameof(DateTime):
                    {
                        DateTime = Convert.ToDateTime(value);
                        return true;
                    }
                case nameof(DateTimeOffset):
                    {
                        DateTimeOffset = DateTimeOffset.Parse(value.ToString());
                        return true;
                    }

                case nameof(Guid):
                    {
                        Guid = Guid.Parse(value.ToString());
                        return true;
                    }
                default:
                    return false;
            }
        }
    }
}

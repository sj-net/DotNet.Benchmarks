using Bogus;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Dynamic;
using System.Text.Json;

namespace Dotnet.WebAPI.Controllers
{
    [ApiController]
    [Route("/api/benchmarks/[controller]/[action]")]
    [FormatFilter]
    public class SerialzationController : ControllerBase
    {
        public static List<ExpandoObject> dump = new List<ExpandoObject>();

        public SerialzationController()
        {
            if (dump.Count == 0)
            {
                var f = new Faker();
                for (int i = 0; i < 50000; i++)
                {
                    var t = new ExpandoObject();

                    if (t is IDictionary<string, object> eo)
                    {
                        eo["String"] = f.Random.String2(100);
                        eo["Bool"] = f.Random.Bool();
                        eo["DateTime"] = f.Person.DateOfBirth;
                        eo["Double"] = f.Random.Double(0.0d, 10000.0d);
                        eo["Int"] = f.Random.Int();
                        eo["Float"] = f.Random.Float(0, 10000);
                        eo["1String"] = f.Random.String2(100);
                        eo["1Bool"] = f.Random.Bool();
                        eo["1DateTime"] = f.Person.DateOfBirth;
                        eo["1Double"] = f.Random.Double(0.0d, 10000.0d);
                        eo["1Int"] = f.Random.Int();
                        eo["1Float"] = f.Random.Float(0, 10000);
                        eo["a_String"] = f.Random.String2(100);
                        eo["a_Bool"] = f.Random.Bool();
                        eo["a_DateTime"] = f.Person.DateOfBirth;
                        eo["a_Double"] = f.Random.Double(0.0d, 10000.0d);
                        eo["a_Int"] = f.Random.Int();
                        eo["a_Float"] = f.Random.Float(0, 10000);
                        eo["a_1String"] = f.Random.String2(100);
                        eo["a_1Bool"] = f.Random.Bool();
                        eo["a_1DateTime"] = f.Person.DateOfBirth;
                        eo["a_1Double"] = f.Random.Double(0.0d, 10000.0d);
                        eo["a_1Int"] = f.Random.Int();
                        eo["a_1Float"] = f.Random.Float(0, 10000);
                        eo["b_String"] = f.Random.String2(100);
                    }

                    dump.Add(t);
                }
            }

        }

        [HttpGet]
        public IEnumerable<ExpandoObject> GetExpando()
        {
            return dump;
        }
    }
}
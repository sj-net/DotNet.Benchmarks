using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Dotnet.WebAPI.Formatters
{

    public class MessagePackOutputFormatter : OutputFormatter
    {
        public MessagePackOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/msgpack"));
        }

        protected override bool CanWriteType(Type? type) => true;

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context)
        {
            await context.HttpContext.Response.BodyWriter.WriteAsync(MessagePack.MessagePackSerializer.Serialize(context.Object, new MessagePack.MessagePackSerializerOptions(MessagePack.Resolvers.ContractlessStandardResolver.Instance)));
        }

        public override bool CanWriteResult(OutputFormatterCanWriteContext context)
        {
            return context.HttpContext.Request.Headers.TryGetValue("Accept", out StringValues e) && e.Any(r => r.ToLower().Equals("application/msgpack"));
        }
    }
}

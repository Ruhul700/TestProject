using System.Text.Json;
using System.Text;

namespace Test.WebAssembly
{
    public static class Helper
    {
        public static StringContent PostData<T>(T t) where T : class => new(JsonSerializer.Serialize(t), Encoding.UTF8, "application/json");

        public static T ReadResponseMessage<T>(HttpResponseMessage message) => JsonSerializer.Deserialize<T>(message.Content.ReadAsStringAsync().Result);

        public static string ReadStringResponse(HttpResponseMessage message) => message.Content.ReadAsStringAsync().Result;
    }
}

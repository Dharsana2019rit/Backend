using System.Text.Json;
using System.Text.Json.Serialization;

namespace Restro
{
    public static class CustomJsonSerializerOptions
    {
        public static JsonSerializerOptions GetJsonSerializerOptions()
        {
            var options = new JsonSerializerOptions
            {
                // Add any custom options here
                // For example, to handle circular references:
                ReferenceHandler = ReferenceHandler.Preserve
            };
            return options;
        }
    }
}


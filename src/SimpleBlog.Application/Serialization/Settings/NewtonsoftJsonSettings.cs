using Newtonsoft.Json;
using SimpleBlog.Application.Interfaces.Serialization.Settings;

namespace SimpleBlog.Application.Serialization.Settings
{
    public class NewtonsoftJsonSettings : IJsonSerializerSettings
    {
        public JsonSerializerSettings JsonSerializerSettings { get; } = new();
    }
}
using System.Text.Json;
using SimpleBlog.Application.Interfaces.Serialization.Options;

namespace SimpleBlog.Application.Serialization.Options
{
    public class SystemTextJsonOptions : IJsonSerializerOptions
    {
        public JsonSerializerOptions JsonSerializerOptions { get; } = new();
    }
}
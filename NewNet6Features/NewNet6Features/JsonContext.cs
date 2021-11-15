using System.Text.Json.Serialization;

namespace NewNet6Features;

[JsonSerializable(typeof(JsonMessage))]
internal partial class JsonContext : JsonSerializerContext
{
}
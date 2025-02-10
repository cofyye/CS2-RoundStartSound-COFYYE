using System.Text.Json.Serialization;

namespace RoundStartSound_COFYYE.Classes
{
    public class Sound(string chatText, string path, bool canPlay)
    {
        [JsonPropertyName("chat_text")]
        public string ChatText { get; init; } = chatText;

        [JsonPropertyName("path")]
        public string Path { get; init; } = path;

        [JsonPropertyName("can_play")]
        public bool CanPlay { get; init; } = canPlay;
    }
}

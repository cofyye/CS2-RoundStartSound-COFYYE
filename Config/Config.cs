using CounterStrikeSharp.API.Core;
using RoundStartSound_COFYYE.Classes;
using System.Text.Json.Serialization;

namespace RoundStartSound_COFYYE.Config
{
    public class Config : BasePluginConfig
    {
        [JsonPropertyName("enable_roundstart_chat_message")]
        public bool EnableRoundStartChatMessage { get; init; } = true;

        [JsonPropertyName("enable_countdown_chat_message")]
        public bool EnableCountDownChatMessage { get; init; } = true;

        [JsonPropertyName("enable_countdown_on_freezetime")]
        public bool EnableCountDownOnFreezeTime { get; init; } = true;

        [JsonPropertyName("countdown_from_x_to_zero")]
        public int CountDownFromXToZero { get; init; } = 5;

        [JsonPropertyName("use_man_countdown_voice")]
        public bool UseManCountDownVoice { get; init; } = true;

        [JsonPropertyName("sounds")]
        public List<Sound> Sounds { get; init; } =
        [
            new Sound("play.chat", "sounds/roundstart/play.vsnd_c", true),
            new Sound("pickupyourweaponandfight.chat", "sounds/roundstart/pickupyourweaponandfight.vsnd_c", true),
            new Sound("prepareforbattle.chat", "sounds/roundstart/prepareforbattle.vsnd_c", true),
            new Sound("prepareforfight.chat", "sounds/roundstart/prepareforfight.vsnd_c", true),
        ];

        [JsonPropertyName("male_countdowns")]
        public List<string> MaleCountDowns { get; init; } =
        [
            "sounds/countdown/man/10.vsnd_c",
            "sounds/countdown/man/9.vsnd_c",
            "sounds/countdown/man/8.vsnd_c",
            "sounds/countdown/man/7.vsnd_c",
            "sounds/countdown/man/6.vsnd_c",
            "sounds/countdown/man/5.vsnd_c",
            "sounds/countdown/man/4.vsnd_c",
            "sounds/countdown/man/3.vsnd_c",
            "sounds/countdown/man/2.vsnd_c",
            "sounds/countdown/man/1.vsnd_c"
        ];

        [JsonPropertyName("female_countdowns")]
        public List<string> FemaleCountDowns { get; init; } =
        [
            "sounds/countdown/fvox/10.vsnd_c",
            "sounds/countdown/fvox/9.vsnd_c",
            "sounds/countdown/fvox/8.vsnd_c",
            "sounds/countdown/fvox/7.vsnd_c",
            "sounds/countdown/fvox/6.vsnd_c",
            "sounds/countdown/fvox/5.vsnd_c",
            "sounds/countdown/fvox/4.vsnd_c",
            "sounds/countdown/fvox/3.vsnd_c",
            "sounds/countdown/fvox/2.vsnd_c",
            "sounds/countdown/fvox/1.vsnd_c"
        ];
    }
}

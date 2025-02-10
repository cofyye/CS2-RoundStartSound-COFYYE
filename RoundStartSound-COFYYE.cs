using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Translations;
using CounterStrikeSharp.API.Modules.Cvars;
using CounterStrikeSharp.API.Modules.Timers;
using Microsoft.Extensions.Logging;
using RoundStartSound_COFYYE.Classes;

namespace RoundStartSound_COFYYE;

public class RoundStartSound_COFYYE : BasePlugin, IPluginConfig<Config.Config>
{
    public override string ModuleName => "RoundStartSound";
    public override string ModuleVersion => "1.0";
    public override string ModuleAuthor => "cofyye";
    public override string ModuleDescription => "https://github.com/cofyye";

    public Config.Config Config { get; set; } = new();

    private List<Sound> _sounds = [];
    private List<string> _manCountdown = [];
    private List<string> _femaleCountdown = [];

    public void OnConfigParsed(Config.Config config)
    {
        Config = config ?? throw new ArgumentNullException(nameof(config));

        if(Config?.Sounds == null ||
           Config?.MaleCountDowns == null ||
           Config?.FemaleCountDowns == null ||
           Config?.EnableCountDownChatMessage == null ||
           Config?.EnableRoundStartChatMessage == null ||
           Config?.EnableCountDownOnFreezeTime == null ||
           Config?.CountDownFromXToZero == null ||
           Config?.UseManCountDownVoice == null
        )
        {
            Logger.LogError("Config fields are null.");
            throw new ArgumentNullException(nameof(config));
        }

        _sounds = Config.Sounds;
        _manCountdown = Config.MaleCountDowns;
        _femaleCountdown = Config.FemaleCountDowns;
    }

    public override void Load(bool hotReload)
    {
        base.Load(hotReload);

        RegisterEventHandler<EventRoundStart>(RoundStartHandler);
        RegisterEventHandler<EventRoundFreezeEnd>(RoundFreezeEndHandler);
    }

    public override void Unload(bool hotReload)
    {
        base.Unload(hotReload);

        DeregisterEventHandler<EventRoundStart>(RoundStartHandler);
        DeregisterEventHandler<EventRoundFreezeEnd>(RoundFreezeEndHandler);
    }

    public HookResult RoundStartHandler(EventRoundStart @event, GameEventInfo info)
    {
        if (@event == null) return HookResult.Continue;

        var gameRulesEntities = Utilities.FindAllEntitiesByDesignerName<CCSGameRulesProxy>("cs_gamerules");
        var gameRules = gameRulesEntities.First().GameRules;

        if (gameRules == null)
        {
            Logger.LogError("Game rules not found.");
            return HookResult.Continue;
        }

        if (_manCountdown.Count == 0 || 
            _femaleCountdown.Count == 0 || 
            Config.EnableCountDownOnFreezeTime == false ||
            gameRules.WarmupPeriod
        ) return HookResult.Continue;

        var freezeTime = ConVar.Find("mp_freezetime")?.GetPrimitiveValue<int>();

        if(freezeTime == null || freezeTime < 1)  return HookResult.Continue;

        CounterStrikeSharp.API.Modules.Timers.Timer? timer = null;

        timer = AddTimer(1.0f, () => {
            freezeTime--;

            if (Config.CountDownFromXToZero >= freezeTime)
            {
                var players = Utilities.GetPlayers().Where(p => p != null && p.IsValid && !p.IsBot && !p.IsHLTV && p.Connected == PlayerConnectedState.PlayerConnected);
                
                string? sound = "";
                
                if(Config.UseManCountDownVoice)
                {
                    sound = _manCountdown.FirstOrDefault(s => s.Contains($"/{freezeTime}.vsnd_c"));
                }
                else
                {
                    sound = _femaleCountdown.FirstOrDefault(s => s.Contains($"/{freezeTime}.vsnd_c"));
                }

                foreach (var player in players)
                {

                    if (Config.EnableCountDownChatMessage)
                    {
                        player.PrintToChat(Localizer.ForPlayer(player, "round.will.start.chat").Replace("{SECONDS_REMAINING}", freezeTime.ToString()));
                    }

                    if (sound == null || sound == "") continue;

                    if(freezeTime == 1)
                    {
                        Server.NextFrame(() => { player.ExecuteClientCommand($"play {sound}"); });
                    }
                    else
                    {
                        player.ExecuteClientCommand($"play {sound}");
                    }
                }
            }

            if (timer != null && freezeTime <= 1)
            {
                timer?.Kill();
            }
        }, TimerFlags.REPEAT);

        return HookResult.Continue;
    }

    public HookResult RoundFreezeEndHandler(EventRoundFreezeEnd @event, GameEventInfo info)
    {
        if (@event == null) return HookResult.Continue;
        if (_sounds.Count == 0) return HookResult.Continue;

        var choosedSong = _sounds[new Random().Next(_sounds.Count)];

        var players = Utilities.GetPlayers().Where(p => p != null && p.IsValid && !p.IsBot && !p.IsHLTV && p.Connected == PlayerConnectedState.PlayerConnected);

        foreach (var player in players)
        {
            if(Config.EnableRoundStartChatMessage)
            {
                player.PrintToChat(Localizer.ForPlayer(player, choosedSong.ChatText));
            }
           
            if (choosedSong.CanPlay)
            {
                player.ExecuteClientCommand($"play {choosedSong.Path}");
            }
        }

        return HookResult.Continue;
    }
}

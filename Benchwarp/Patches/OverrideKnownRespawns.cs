using Benchwarp.Benches;

namespace Benchwarp.Patches
{
    internal static class OverrideKnownRespawns
    {
        internal static void Hook()
        {
            On.GameManager.GetRespawnInfo += OverrideGetRespawnInfo;
        }

        internal static void Unhook()
        {
            On.GameManager.GetRespawnInfo -= OverrideGetRespawnInfo;
        }

        private static void OverrideGetRespawnInfo(On.GameManager.orig_GetRespawnInfo orig, GameManager self, out string scene, out string marker)
        {
            if (BenchList.CurrentBenchRespawn is BenchData bd)
            {
                RespawnInfo benchRespawn = bd.RespawnInfo.GetRespawnInfo();
                scene = benchRespawn.SceneName;
                marker = benchRespawn.RespawnMarkerName;
                return;
            }

            RespawnInfo startRespawn = Events.BenchListModifiers.GetStartDef();
            if (startRespawn.IsCurrentRespawn())
            {
                scene = startRespawn.SceneName;
                marker = startRespawn.RespawnMarkerName;
                return;
            }

            orig(self, out scene, out marker);
        }
    }
}

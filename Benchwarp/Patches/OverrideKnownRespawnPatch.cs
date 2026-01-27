using Benchwarp.Benches;
using HarmonyLib;

namespace Benchwarp.Patches
{
    [HarmonyPatch(typeof(GameManager), nameof(GameManager.GetRespawnInfo))]
    internal static class OverrideKnownRespawnPatch
    {
        [HarmonyPrefix]
        private static bool OverrideGetRespawnInfo(ref string scene, ref string marker)
        {
            if (BenchList.CurrentBenchRespawn is BenchData bd)
            {
                RespawnInfo benchRespawn = bd.RespawnInfo.GetRespawnInfo();
                scene = benchRespawn.SceneName;
                marker = benchRespawn.RespawnMarkerName;
                return false;
            }

            RespawnInfo startRespawn = Events.BenchListModifiers.GetStartDef();
            if (startRespawn.IsCurrentRespawn())
            {
                scene = startRespawn.SceneName;
                marker = startRespawn.RespawnMarkerName;
                return false;
            }
            return true;
        }

        [HarmonyPostfix]
        private static void RecordGetRespawnInfoFallthrough(GameManager __instance, ref string scene, ref string marker)
        {
            if (scene == "Tut_01" && __instance.playerData.respawnScene != "Tut_01")
            {
                BenchwarpPlugin.Instance.Logger.LogWarning($"Unrecognized respawn at " +
                    $"{__instance.playerData.respawnMarkerName} in {__instance.playerData.respawnScene}, " +
                    $"GameManager.GetRespawnInfo will fall through to Tut_01.");
            }
        }
    }
}

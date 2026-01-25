using GlobalEnums;
using PrepatcherPlugin;

namespace Benchwarp.Benches;

/// <summary>
/// The basic data required to check or set a respawn.
/// </summary>
public sealed record RespawnInfo(string SceneName, string RespawnMarkerName, int RespawnType, MapZone MapZone) : IRespawnInfo
{
    public static RespawnInfo FromPlayerData()
    {
        return new(PlayerDataAccess.respawnScene, PlayerDataAccess.respawnMarkerName, PlayerDataAccess.respawnType, PlayerDataAccess.mapZone);
    }

    public static bool ReferToSameMarker(RespawnInfo r1, RespawnInfo r2)
    {
        return r1.SceneName == r2.SceneName && r1.RespawnMarkerName == r2.RespawnMarkerName;
    }

    RespawnInfo IRespawnInfo.GetRespawnInfo() => this;
    public void SetRespawn()
    {
        PlayerDataAccess.respawnScene = SceneName;
        PlayerDataAccess.respawnMarkerName = RespawnMarkerName;
        PlayerDataAccess.respawnType = RespawnType;
        PlayerDataAccess.mapZone = MapZone;
    }

    public bool IsCurrentRespawn() 
        => PlayerDataAccess.respawnScene == SceneName && PlayerDataAccess.respawnMarkerName == RespawnMarkerName;
}

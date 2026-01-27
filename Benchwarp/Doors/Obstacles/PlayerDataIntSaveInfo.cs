namespace Benchwarp.Doors.Obstacles;

public record PlayerDataIntSaveInfo(string PlayerDataIntName, int Value) : ObstacleSaveInfo
{
    public override void Save(RoomData room, DoorData gate, string objName)
    {
        PlayerData.instance.SetInt(PlayerDataIntName, Value);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

namespace Benchwarp.Doors.Obstacles;

/// <summary>
/// An <see cref="ObstacleInfo"/> of which enabling/disabling a Behaviour affects the obstacle.
/// </summary>
public record BehaviourObstacleInfo<T>(string ObjPath, bool Enable, ObstacleType Type, ObstacleSeverity Severity, ObstacleSaveInfo? SaveInfo = null, int Index = 0)
    : ObstacleInfo(ObjPath, Type, Severity, SaveInfo) where T : Behaviour
{
    public Behaviour? FindBehaviour(Scene scene) => FindObj(scene)?.GetComponents<T>().ElementAtOrDefault(Index);

    public override void Open(Scene scene)
    {
        if (FindBehaviour(scene) is Behaviour b && b)
        {
            b.enabled = Enable;
        }
    }
}
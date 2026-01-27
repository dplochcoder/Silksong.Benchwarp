using UnityEngine.SceneManagement;

namespace Benchwarp.Doors.Obstacles;

/// <summary>
/// An <see cref="ObstacleInfo"/> of which toggling a TestGameObjectActivator's GameObjects affects the obstacle.
/// </summary>
public record TestObjObstacleInfo(string ObjPath, bool Activate, ObstacleType Type, ObstacleSeverity Severity, ObstacleSaveInfo? SaveInfo = null, int Index = 0)
    : BehaviourObstacleInfo<TestGameObjectActivator>(ObjPath, Activate, Type, Severity, SaveInfo, Index)
{
    public override void Open(Scene scene)
    {
        if (FindBehaviour(scene) is TestGameObjectActivator tgoa && tgoa)
        {
            tgoa.enabled = false;

            tgoa.activateGameObject?.SetActive(Activate);
            tgoa.deactivateGameObject?.SetActive(!Activate);
        }
    }
}

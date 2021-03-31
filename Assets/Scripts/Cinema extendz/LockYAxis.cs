using UnityEngine;
using Cinemachine;

public class LockYAxis : CinemachineExtension
{
    public float YPosition;

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (enabled && stage == CinemachineCore.Stage.Body)
        {
            var pos = state.RawPosition;
            pos.y = YPosition;
            state.RawPosition = pos;
        }
    }
}

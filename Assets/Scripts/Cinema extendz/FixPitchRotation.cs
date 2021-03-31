using Cinemachine;
using UnityEngine;

public class FixPitchRotation : CinemachineExtension
{
    public float PitchAngle;

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (enabled && stage == CinemachineCore.Stage.Body)
        {
            state.RawOrientation = Quaternion.Euler(PitchAngle, state.CorrectedOrientation.eulerAngles.y, state.CorrectedOrientation.eulerAngles.y);
        }
    }
}

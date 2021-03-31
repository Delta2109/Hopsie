using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Vector3 NewPosition;

    public void SetCameraPosition(Transform camera)
    {
        camera.position = NewPosition;
    }
}

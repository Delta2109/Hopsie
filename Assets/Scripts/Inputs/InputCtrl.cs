using UnityEngine;

public abstract class InputCtrl : MonoBehaviour
{
    public abstract bool Move();
    public float direction = 0f;
}

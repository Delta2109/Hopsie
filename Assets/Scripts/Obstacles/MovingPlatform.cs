using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<NoHop>().SetRidingOnPlatform(true, this.transform);
    }

    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<NoHop>().SetRidingOnPlatform(false, null);
    }
}

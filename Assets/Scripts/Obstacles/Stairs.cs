using UnityEngine;

public class Stairs : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<NoHop>().SetForStairs();
    }
}

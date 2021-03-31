using UnityEngine;

public class Climbing : MonoBehaviour
{
    public bool GoingUp;
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<NoHop>().SetForClimbing(GoingUp);
    }
}

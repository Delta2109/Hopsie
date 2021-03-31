using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndClimb : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<NoHop>().ExitHeight();
    }
}

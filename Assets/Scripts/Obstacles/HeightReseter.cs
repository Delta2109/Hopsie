using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightReseter : MonoBehaviour
{
    public float NewHeight;
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<NoHop>().SetNewTargetHeight(NewHeight);
    }
}

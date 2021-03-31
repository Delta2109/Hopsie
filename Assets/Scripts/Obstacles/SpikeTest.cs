using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTest : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<NoHop>().SetChekingBottom(true);
    }
    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<NoHop>().SetChekingBottom(false);
    }
}

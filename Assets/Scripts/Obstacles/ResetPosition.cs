using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    [HideInInspector]
    public Vector3 Position;

    void Start()
    {
        Position = transform.TransformPoint(GetComponent<BoxCollider>().center);
        Position.y = 0.1f;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<CollisionM>().SetObstacleStartPosition(Position);
    }
}

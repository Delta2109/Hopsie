using UnityEngine;

public class CollisionM : MonoBehaviour
{
    private NoHop nohop;
    private Vector3 obstacleStart;
    
    public void SetObstacleStartPosition(Vector3 pos)
    {
        obstacleStart = pos;
    }
    public void SetToObstacleStart()
    {
        nohop.TeleportToPosition(obstacleStart);
    }
    private void Start()
    {
        nohop = GetComponent<NoHop>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.transform.CompareTag("floor"))
            return;
        SetToObstacleStart();
    }
}

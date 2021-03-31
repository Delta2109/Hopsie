using UnityEngine;

public class ReplayLevel : MonoBehaviour
{
    public NoHop Player;
    private GamePlayCtrl gpc;    

    //on UI button
    public void Replay()
    {
        Player.enabled = false;
        Player.Reset();
        gpc.StartLevel();
    }

    private void Start()
    {
        gpc = GetComponent<GamePlayCtrl>();
    }
}

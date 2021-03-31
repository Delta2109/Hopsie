using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public delegate void GameOver();
    public static event GameOver OnGameOver;

    public InputCtrl aiinput;
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<NoHop>().input = aiinput;
        aiinput.enabled = true;
        if(OnGameOver != null)
        {
            OnGameOver();
        }
    }
}

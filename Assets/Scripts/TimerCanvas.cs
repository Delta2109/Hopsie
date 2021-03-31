using UnityEngine.UI;
using UnityEngine;

public class TimerCanvas : MonoBehaviour
{
    public Text currentTimeTxt;
    public Text TopTimeTxt;

    public void UpdateTimerTxt(float timeSeconds)
    {
        int conTime = (int)timeSeconds;
        string minute = (conTime / 60).ToString("00");
        string second = (conTime % 60).ToString("00");
        string milisec = ((timeSeconds * 100) % 100).ToString("00");
        currentTimeTxt.text = $"{minute}:{second}:{milisec}";
    }

    public void SetTopTime(float toptime)
    {
        int conTime = (int)toptime;
        string minute = (conTime / 60).ToString("00");
        string second = (conTime % 60).ToString("00");
        TopTimeTxt.text = $"{minute}:{second}";
    }
}

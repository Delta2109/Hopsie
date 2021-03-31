using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    public TimerCanvas timerCanvas;

    private bool isLevelStarted = false;
    private float timeCount = 0f;
    private float startTime = 0f;

    private float topTime = 60f;

    public void TimeCheck()
    {
        isLevelStarted = false;
        if(timeCount < topTime)
        {
            timerCanvas.SetTopTime(timeCount);
            topTime = timeCount;
        }
    }
    public void StartLevelTimer()
    {
        startTime = Time.time;
        isLevelStarted = true;
    }

    private void Update()
    {
        if (isLevelStarted)
        {
            timeCount = Time.time - startTime;
            timerCanvas.UpdateTimerTxt(timeCount);
        }
    }
}

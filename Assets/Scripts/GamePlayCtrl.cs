using System.Collections;
using UnityEngine;

public class GamePlayCtrl : MonoBehaviour
{
    public LevelTimer levelTimer;
    public StartCanvas startCanvas;   
    public GameObject inputCtrl;
    public GameObject endTimeline;

    private void Start()
    {
        StartLevel();
        FinishLine.OnGameOver += GameOverSeq;
    }

    public void StartLevel()
    {
        startCanvas.NewGameSesion();
        inputCtrl.SetActive(false);
    }

    //on UI button
    public void TapStart()
    {
        startCanvas.TapedToStart();
        StartCoroutine(StartProcedure());
        endTimeline.SetActive(false);
    }

    private IEnumerator StartProcedure()
    {
        for (int i = 1; i < 4; i++)
        {
            yield return new WaitForSeconds(0.75f);
            startCanvas.CountImg(i);
        }
        startCanvas.EndCount();
        inputCtrl.SetActive(true);
        levelTimer.StartLevelTimer();
    }

    private void GameOverSeq()
    {
        endTimeline.SetActive(true);
        levelTimer.TimeCheck();
    }

    private void OnDisable()
    {
        FinishLine.OnGameOver -= GameOverSeq;
    }
}

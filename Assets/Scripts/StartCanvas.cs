using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StartCanvas : MonoBehaviour
{
    public Canvas startCanvas;
    public Image Counter;
    public Image JumpInfoImg;
    public GameObject startTap;
    public Sprite[] countImgs;

    public void TapedToStart()
    {
        startTap.SetActive(false);
        JumpInfoImg.enabled = true;
        Counter.enabled = true;
    }
    public void CountImg(int i)
    {
        Counter.sprite = countImgs[i];
    }
    public void EndCount()
    {
        StartCoroutine(ExitingCounter());
    }
    public void NewGameSesion()
    {
        JumpInfoImg.enabled = false;
        Counter.sprite = countImgs[0];
        Counter.enabled = false;
        startTap.SetActive(true);
        startCanvas.enabled = true;
    }
    private IEnumerator ExitingCounter()
    {
        yield return new WaitForSeconds(0.6f);
        startCanvas.enabled = false;
    }
}

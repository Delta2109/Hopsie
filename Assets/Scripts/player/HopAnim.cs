using UnityEngine;

public class HopAnim : MonoBehaviour
{
    public Animator animator;
    private int hopAnimId;

    private void Start()
    {
        hopAnimId = Animator.StringToHash("hop");
    }
    public void TrigerHopAnim()
    {        
        animator.SetTrigger(hopAnimId);
    }
}

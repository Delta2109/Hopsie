using UnityEngine;

public class AIInput : InputCtrl
{
    public float rp = 1f;
    private float nextToMoveDecision = 0.5f;
    private float timeElapsed = 0f;

    private float directionDecisionTime = 0.2f;

    private bool toMove = true;

    public override bool Move()
    {
        return toMove;
    }
    
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if(timeElapsed > nextToMoveDecision)
        {
            toMove = true;//(Random.Range(1, 100) > 90) ? false : true;
            timeElapsed = 0f;
        }

        directionDecisionTime -= Time.deltaTime;
        if (directionDecisionTime < 0f)
        {
            directionDecisionTime = 0.25f;
            var sample = 1.6667f * Mathf.PerlinNoise(Time.time * 2f, rp);
            if(sample < 0.23f)
            {
                direction = -1f;
            }
            else if(sample > 0.77f)
            {
                direction = 0f;
            }
            else
            {
                direction = 0f;
            }
        }

    }

    private void OnDisable()
    {
        toMove = false;
    }
}

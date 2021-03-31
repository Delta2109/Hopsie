using UnityEngine;
using System.Collections;

public class NoHop : MonoBehaviour
{
    public InputCtrl input;
    private Rigidbody controller;
    private HopAnim hopanim;
    private Vector3 targetPos;
    private bool isHop = false;
    private bool isRiding = false;
    private bool isoverHole = false;
    private Vector3 positionOffset;
    private Vector3 moveDirection = Vector3.forward;
    private Vector3 velocityDirection = new Vector3(0f, 1f, 1f);
    private Transform platformTrans;
    private Vector3 movigPlatformOffset = new Vector3(0f, 0f, 0.5f);
    private Vector3 targetHeightOffset = Vector3.zero;
    private float XPos;

    private InputCtrl saveInputRef;

    void Start()
    {
        saveInputRef = input;
        controller = GetComponent<Rigidbody>();
        hopanim = GetComponent<HopAnim>();
        XPos = transform.position.x;
    }

    void Update()
    {
        if (input.Move())
        {
            if (!isHop)
            {
                hopanim.TrigerHopAnim();
                targetPos = transform.position + moveDirection + targetHeightOffset;
                positionOffset = velocityDirection;
                isHop = true;
                isRiding = false;
            }
        }
        if(isoverHole)
        {
            if(!isRiding)
            {
                isoverHole = false;
                //this.enabled = false;
                GetComponent<CollisionM>().SetToObstacleStart();
            }
        }
    }
    private void FixedUpdate()
    {
        if (isHop)
        {
            positionOffset.y -= Time.fixedDeltaTime * 6f;
            controller.MovePosition(controller.position + positionOffset * Time.fixedDeltaTime * 3f);
            if (transform.position.z >= targetPos.z)
            {
                transform.position = targetPos;
                isHop = false;
            }
        }
        if (isRiding)
        {
            controller.position = MoveOnPlatform();
        }
    }

    private Vector3 MoveOnPlatform() => platformTrans.position + movigPlatformOffset;

    private IEnumerator ResetAfterHit(Vector3 newpos)
    {
        yield return new WaitForSeconds(1f);
        controller.useGravity = false;
        controller.isKinematic = true;
        controller.velocity = Vector3.zero;
        controller.angularVelocity = Vector3.zero;
        yield return new WaitForSeconds(0.05f);        
        newpos.x = XPos;
        targetPos.y = newpos.y;
        targetPos.z = newpos.z;
        controller.position = newpos;
        transform.rotation = Quaternion.identity;
        yield return new WaitForSeconds(0.01f);
        this.enabled = true;
        isHop = true;
        //controller.MovePosition(newpos);        
    }

    public void TeleportToPosition(Vector3 newPos)
    {
        if (!this.enabled)
            return;
        this.enabled = false;
        controller.useGravity = true;
        controller.isKinematic = false;
        StartCoroutine(ResetAfterHit(newPos));
    }    

    public void SetRidingOnPlatform(bool set, Transform platform)
    {
        isRiding = set;
        platformTrans = platform;
    }

    public void SetChekingBottom(bool set)
    {
        isoverHole = set;
    }
    public void SetForStairs()
    {
        velocityDirection = new Vector3(0f, 1.5f, 1f);
        targetHeightOffset.y = 0.4f;
    }

    public void ExitHeight()
    {
        moveDirection = new Vector3(0f, 0f, 1f);
        velocityDirection = new Vector3(0f, 1f, 1f);
        targetHeightOffset.y = 0f;
    }

    public void SetForClimbing(bool goingUp)
    {
        moveDirection = new Vector3(0f, 0f, 0.5f);
        //velocityDirection = new Vector3(0f, 1f, 0.5f);
        float dir = goingUp ? 1f : -1f;
        targetHeightOffset.y = 0.09f * dir;
    }

    public void SetNewTargetHeight(float height)
    {
        targetPos.y = height;
    }

    public void Reset()
    {
        targetPos = new Vector3(0f, 0.1f, 0.5f);
        controller.position = new Vector3(0f, 0.1f, 0.5f);
        controller.velocity = Vector3.zero;
        input = saveInputRef;
        this.enabled = true;
    }
}

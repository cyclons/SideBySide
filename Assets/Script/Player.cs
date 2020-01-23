using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Player : MonoBehaviour {
    public float horizonSpeed = 3;
    public float extraSpeed = 0;
    public float extraSpeedY = 0;
    public float JumpForce = 3;
    public float jumpRayLength = 1;
    public playerLeg[] legObjs;
    public Transform[] TriPosGroup;
    [HideInInspector]
    public Rigidbody2D RidBall;
    public ShapeInfo shapeInfo;

    public ShapeInfo currentShapInfo = new ShapeInfo();
    public bool isNearTotem = false;
    public AudioClip jumpClip;
    private Animator animator;
    private float normalGravityScale;
    private bool isSpeedDown = false;
    private void Start()
    {
        animator = GetComponent<Animator>();
        RidBall = GetComponent<Rigidbody2D>();
        normalGravityScale = RidBall.gravityScale;

        RemoveShape();
        animator.ResetTrigger("goRun");
    }
    private void Update()
    {
        if (isNearTotem&&Input.GetKeyDown(KeyCode.E))
        {
            BuildShape(shapeInfo);
        }
        if(!isNearTotem && Input.GetKeyDown(KeyCode.E))
        {
            RemoveShape();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            LevelManager.Instance.RestartLevel();
        }
        //RaycastHit2D hit;
        if (!isSpeedDown&&(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)))
        {
            RidBall.gravityScale = normalGravityScale*4;
            isSpeedDown = true;
        }else if(isSpeedDown&&(IsGrounded() || Physics2D.Linecast(transform.position, transform.position + new Vector3(0, -jumpRayLength),LayerMask.GetMask("JumpGround") )))
        {
            //Debug.Log(hit.collider.name);
            RidBall.gravityScale = normalGravityScale;
            isSpeedDown = false;
        }

    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float speed = Input.GetAxis("Horizontal") * horizonSpeed;

        RidBall.velocity = (new Vector2(speed+extraSpeed, RidBall.velocity.y+extraSpeedY));

        if (speed < 0)
        {
            animator.SetBool("IsWalkingLeft", true);
            animator.SetBool("IsWalkingRight", false);
        }else if (speed > 0)
        {
            animator.SetBool("IsWalkingLeft", false);
            animator.SetBool("IsWalkingRight", true);
        }else if(speed == 0)
        {
            animator.SetBool("IsWalkingLeft", false);
            animator.SetBool("IsWalkingRight", false);
        }
        if (!isSpeedDown)
        {
            if (RidBall.velocity.y < 0)
            {
                RidBall.gravityScale = normalGravityScale * 1.5f;
            }
            else
            {
                RidBall.gravityScale = normalGravityScale ;
            }

        }

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            if (IsGrounded())
            {
                RidBall.velocity = (new Vector2(RidBall.velocity.x, JumpForce));
                AudioManager.Instance.PlayQuikly(jumpClip);

            }
        }

        Debug.DrawLine(transform.position, transform.position + new Vector3(0, -jumpRayLength), Color.green);

    }
    
    public bool IsGrounded()
    {
        bool isGround = false;
        if(Physics2D.Linecast(transform.position, transform.position + new Vector3(0, -jumpRayLength), 1 << LayerMask.GetMask("Player","JumpGround"))
            || Physics2D.Linecast(transform.position, transform.position + new Vector3(-0.3f, -jumpRayLength), 1 << LayerMask.GetMask("Player", "JumpGround"))
            || Physics2D.Linecast(transform.position, transform.position + new Vector3(0.3f, -jumpRayLength), 1 << LayerMask.GetMask("Player", "JumpGround")))
        {
            isGround = true;
        }
        if (isGround)
        {
            return isGround;
        }

        foreach (var leg in legObjs)
        {
            isGround = leg.IsGrounded();
            if (isGround)
            {
                return isGround;
            }
        }

        return isGround;
    }

    private bool hasBuild = false;
    public void BuildShape(ShapeInfo info)
    {
        animator.ResetTrigger("goRun");
        animator.ResetTrigger("goIdle");

        bool isIdole = false;
        bool hasleg0 = false, hasleg1 = false;
        currentShapInfo = info;
        hasBuild = true;
        if (info.shownTriArray.Length <= LevelManager.Instance.TriNum-1)
        {
            PickUpTri[] pickups = transform.Find("TriContainer").GetComponentsInChildren<PickUpTri>();
            int i = 0;
            for(i = 0; i < info.shownTriArray.Length; i++)
            {
                pickups[i].ShowTri(TriPosGroup[ info.shownTriArray[i]]);
                if (info.shownTriArray[i] == 0)
                {
                    SpriteRenderer[] renderers = legObjs[1].GetComponentsInChildren<SpriteRenderer>();
                    foreach (var renderer in renderers)
                    {
                        renderer.DOColor(new Color(1, 1, 1, 1), 1);
                    }
                    animator.SetTrigger("goIdle");
                    isIdole = true;
                    hasleg1 = true;
                    legObjs[1].enabled = true;
                    legObjs[1].GetComponent<CapsuleCollider2D>().enabled = true;
                }else if(info.shownTriArray[i] == 1)
                {
                    SpriteRenderer[] renderers = legObjs[0].GetComponentsInChildren<SpriteRenderer>();
                    foreach (var renderer in renderers)
                    {
                        renderer.DOColor(new Color(1, 1, 1, 1), 1);
                    }
                    animator.SetTrigger("goIdle");
                    isIdole = true;
                    hasleg0 = true;
                    legObjs[0].enabled = true;
                    legObjs[0].GetComponent<CapsuleCollider2D>().enabled = true;

                }
            }
            


            if (!isIdole)
            {
                animator.SetTrigger("goRun");
                //关闭所有的腿
                foreach (var leg in legObjs)
                {
                    HidePlayerLeg(leg);
                }
            }
            if (!hasleg0)
            {
                HidePlayerLeg(legObjs[0]);
            }
            if (!hasleg1)
            {
                HidePlayerLeg(legObjs[1]);
            }


            for (; i < pickups.Length; i++)
            {
                pickups[i].HideTri();
            }
        }

    }
    public void RemoveShape()
    {
        animator.SetTrigger("goRun");
        currentShapInfo = new ShapeInfo();
        hasBuild = false;
        PickUpTri[] pickups = transform.Find("TriContainer").GetComponentsInChildren<PickUpTri>();
        foreach(var pickup in pickups)
        {
            pickup.HideTri();
        }
        foreach (var leg in legObjs)
        {

            HidePlayerLeg(leg);
        }
    }

    void HidePlayerLeg(playerLeg leg)
    {
        leg.GetComponent<CapsuleCollider2D>().enabled = false;
        leg.enabled = false;
        leg.isGround = false;
        SpriteRenderer[] renderers = leg.GetComponentsInChildren<SpriteRenderer>();
        foreach (var renderer in renderers)
        {
            renderer.DOColor(new Color(1, 1, 1, 0), 0);
        }

    }

    public AudioClip bouceJumpClip;


    private bool isJumpleft=false;
    public void JumpSpring(Vector3 jumpDir)
    {
        StopAllCoroutines();

        AudioManager.Instance.PlayQuikly(bouceJumpClip);

        RidBall.velocity = (jumpDir*1.5f);
        extraSpeed = (jumpDir* 1.5f).x;
        if (extraSpeed <= 0)
        {
            isJumpleft = true;
        }
        else
        {
            isJumpleft = false;
        }
        StartCoroutine(StartJump());
    }
    IEnumerator StartJump()
    {
        if (isJumpleft)
        {
            while (extraSpeed < 0)
            {
                extraSpeed += Time.deltaTime*25;
                yield return new WaitForFixedUpdate();
            }
        }
        else
        {
            while (extraSpeed >= 0)
            {
                extraSpeed -= Time.deltaTime*25;
                yield return new WaitForFixedUpdate();
            }

        }
        extraSpeed = 0;
    }
}

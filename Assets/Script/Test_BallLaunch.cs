using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_BallLaunch : MonoBehaviour {
    public float horizonSpeed = 3;
    public float JumpForce = 8;
    Rigidbody2D RidBall;
    
    private void Start()
    {
        RidBall = GetComponent<Rigidbody2D>();
        
    }
    private void Update()
    {

        float speed = Input.GetAxis("Horizontal")*horizonSpeed;

          RidBall.velocity = (new Vector2(speed, RidBall.velocity.y));

       RidBall.velocity = (new Vector2(RidBall.velocity.x, RidBall.velocity.y-0.1f));
        if (Input.GetKey(KeyCode.Space))
        {

            if (Physics2D.Linecast(transform.position,transform.position+new Vector3(0,-1f) , LayerMask.GetMask("ground")))
            {
                RidBall.velocity = (new Vector2(RidBall.velocity.x, JumpForce));
            }
        }
        Debug.DrawLine(transform.position, transform.position + new Vector3(0, -.6f),Color.green);
    }
    private void OnMouseDown()
    {
        //Debug.Log("You Clicked the Ball");
    }
}

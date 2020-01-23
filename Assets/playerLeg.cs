using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLeg : MonoBehaviour {

    public bool isGround = false;
    public Transform rayPoint;
    public float raylength;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Physics2D.Linecast(rayPoint.position, rayPoint.position + new Vector3(0, -raylength), 1 << LayerMask.GetMask("Player")))
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
        Debug.DrawLine(rayPoint.position, rayPoint.position + new Vector3(0, -raylength), Color.green);


    }

    public bool IsGrounded()
    {
        return isGround;
    }
    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (!collision.collider.CompareTag("Player"))
    //    {
    //        isGround = true;
    //    }
    //}
    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (!collision.collider.CompareTag("Player"))
    //    {
    //        isGround = false;
    //    }
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private float maxX, minX, maxY, minY;
    public Transform FollowObject;
    public Transform leftDown, rightUp;
    // Use this for initialization
    void Start()
    {
        minX = leftDown.position.x;
        minY = leftDown.position.y;
        maxX = rightUp.position.x;
        maxY = rightUp.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (FollowObject != null)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(Mathf.Clamp(FollowObject.position.x, minX, maxX), Mathf.Clamp(FollowObject.position.y, minY, maxY), -10), .05f);
            //transform.position = new Vector3(FollowObject.position.x, FollowObject.position.y,-10);
        }
    }
}

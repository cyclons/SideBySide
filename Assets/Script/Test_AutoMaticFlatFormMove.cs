using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_AutoMaticFlatFormMove : MonoBehaviour {
    public float MoveSpeed;
    public Vector3 MoveDir;
    Transform MoveLeftPoint, MoveRightPoint,FlatFormBody;
    public enum MoveDirection{
        Left,
        Right
    }
    public MoveDirection MovingDir;

    private void Awake()
    {
        FlatFormBody = transform.Find("FlatFormBody").GetComponent<Transform>();
        MoveRightPoint = transform.Find("MoveRightPoint").GetComponent<Transform>();
        MoveLeftPoint = transform.Find("MoveLeftPoint").GetComponent<Transform>();

    }

    // Use this for initialization
    void Start () {
        MoveDir = (MoveRightPoint.position - MoveLeftPoint.position).normalized;
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(MoveDir);
        if (MovingDir == MoveDirection.Right)
        {
            MoveDir = (MoveRightPoint.position - MoveLeftPoint.position).normalized;

            FlatFormBody.position = Vector2.MoveTowards(FlatFormBody.position, MoveRightPoint.position, MoveSpeed * Time.deltaTime);
            if (((Vector2)FlatFormBody.position - (Vector2)MoveRightPoint.position).sqrMagnitude < 0.01f)
            {

                MovingDir = MoveDirection.Left;
            }
        }
        else
        {
            MoveDir = (MoveLeftPoint.position - MoveRightPoint.position).normalized;

            FlatFormBody.position = Vector2.MoveTowards(FlatFormBody.position, MoveLeftPoint.position, MoveSpeed * Time.deltaTime);
            if (((Vector2)FlatFormBody.position - (Vector2)MoveLeftPoint.position).sqrMagnitude < 0.01f)
            {

                MovingDir = MoveDirection.Right;
            }
        }
	}


    private void OnDrawGizmos()
    {
        MoveRightPoint = transform.Find("MoveRightPoint").GetComponent<Transform>();
        MoveLeftPoint = transform.Find("MoveLeftPoint").GetComponent<Transform>();

        Gizmos.DrawWireSphere(MoveLeftPoint.position, 0.5f);
        Gizmos.DrawWireSphere(MoveRightPoint.position, 0.5f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlatFormBody : MonoBehaviour {
    Test_AutoMaticFlatFormMove autoMaticFlatFormMove;
    public Vector3 moveSpeed;
    // Use this for initialization
    void Start () {
        autoMaticFlatFormMove = GetComponentInParent<Test_AutoMaticFlatFormMove>();

    }
	
	// Update is called once per frame
	void Update () {
        moveSpeed = autoMaticFlatFormMove.MoveDir;

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.collider.GetComponent<Player>();
        if (player == null)
        {
            player = collision.collider.GetComponentInParent<Player>();
        }
        if (player != null)
        {
            player.transform.SetParent(transform);
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Player player = collision.collider.GetComponent<Player>();
        if (player == null)
        {
            player = collision.collider.GetComponentInParent<Player>();
        }

        if (player != null)
        {
            player.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Player player = collision.collider.GetComponent<Player>();
        if (player == null)
        {
            player = collision.collider.GetComponentInParent<Player>();
        }

        if (player!=null)
        {
            player.extraSpeed = 0;
            player.extraSpeedY = 0;
            var original = player.GetComponent<TransformState>().OriginalParent;
            player.transform.SetParent(original);
        }

    }
}

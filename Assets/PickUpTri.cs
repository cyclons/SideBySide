using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PickUpTri : MonoBehaviour {

    private bool isAbsorb = false;
    private Transform targetMoveTrans;
    private Vector3 startPoint;
    private float moveTimer = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (isAbsorb&&moveTimer<=1)
        {
            moveTimer += Time.deltaTime*1.5f;
            transform.position = Bezier.GetPoint4(startPoint, startPoint + Vector3.up, targetMoveTrans.position + Vector3.up, targetMoveTrans.position, moveTimer);
        }
        if (isAbsorb && moveTimer > 1)
        {
            GetComponent<TrailRenderer>().enabled = false;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( transform.parent!=null&&transform.parent.name== "TriContainer")
        {
            return;
        }
        Player player = collision.GetComponent<Player>();
        if (player == null)
        {
            player = collision.GetComponentInParent<Player>();
        }
        if (player!=null)
        {
            transform.parent = player.transform.Find("TriContainer");
            GetComponent<PolygonCollider2D>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            Destroy(GetComponent<Rigidbody2D>());
            startPoint = transform.position;
            targetMoveTrans = player.transform;
            transform.DORotate(player.transform.rotation.eulerAngles, 1);
            transform.DOScale(0, 1);
            isAbsorb = true;
            LevelManager.Instance.AddTriangleNum(1);
        }
    }

    public void ShowTri(Transform target)
    {
        GetComponent<PolygonCollider2D>().enabled = true;

        GetComponent<TrailRenderer>().enabled = true;
        startPoint = transform.position;
        targetMoveTrans = target;
        transform.DOScale(1, .5f);
        transform.DORotate(targetMoveTrans.rotation.eulerAngles, 1);
        moveTimer = 0;
    }
    public void HideTri()
    {
        GetComponent<PolygonCollider2D>().enabled = false;

        GetComponent<TrailRenderer>().enabled = false;
        startPoint = transform.position;
        targetMoveTrans = transform.parent;
        transform.DORotate(targetMoveTrans.rotation.eulerAngles, 1);
        transform.DOScale(0, 1);
        moveTimer = 0;

    }
}

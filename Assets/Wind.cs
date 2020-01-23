using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

#if UNITY_EDITOR
[CustomEditor(typeof(Wind))]
[CanEditMultipleObjects] //sure why not

public class WindEditor : Editor
{
    private void OnSceneGUI()
    {
        //Wind wind = target as Wind;
        //Vector3[] points =  { wind.transform.position, wind.transform.position + new Vector3(1,1,0) };
        //Handles.color = Color.blue;
        //Handles.DrawLines(points);
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        //DrawDefaultInspector();
    }
}
#endif
[RequireComponent(typeof(BoxCollider2D))]
public class Wind : MonoBehaviour
{
    public float windForce = 10;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
        if (rb != null && !collision.isTrigger)
        {
            rb.AddForce(windForce * transform.up);
        }
    }
    private void OnDrawGizmos()
    {
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        Gizmos.color = Color.yellow;
        Vector3 bottomPoint = transform.position + boxCollider.offset.x * transform.right + (boxCollider.offset.y-boxCollider.size.y/2) * transform.up;
        Gizmos.DrawLine(bottomPoint, bottomPoint + transform.up * boxCollider.size.y);
        Gizmos.DrawLine(bottomPoint + transform.right * boxCollider.size.x / 2, bottomPoint + transform.right * boxCollider.size.x / 2 + transform.up * GetComponent<BoxCollider2D>().size.y);
        Gizmos.DrawLine(bottomPoint - transform.right * boxCollider.size.x / 2, bottomPoint - transform.right * boxCollider.size.x / 2 + transform.up * GetComponent<BoxCollider2D>().size.y);
        Gizmos.DrawLine(bottomPoint , bottomPoint - transform.right * boxCollider.size.x / 2 );
        Gizmos.DrawLine(bottomPoint , bottomPoint + transform.right * boxCollider.size.x / 2 );

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_DragableFlatForm : MonoBehaviour {
    
    
    private void OnMouseDrag()
    {
        transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,transform.position.y);
    }
}

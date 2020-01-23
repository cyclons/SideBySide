using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBarSet : MonoBehaviour {
    private float MusicVolume;
    private float BrightnessValue;
    private void Start()
    {
        
    }
    private void OnMouseDrag()
    {
            float X = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            if (X >= -1 && X <= 5)
            {
                transform.position = new Vector2(X,transform.position.y);
            }
        
        
    }
}

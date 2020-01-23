using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriangleNumUpdater : MonoBehaviour {

    public Text TotalNumText;
    public int TotalNum = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddTriNum(int addnum=1)
    {
        TotalNum += addnum;
        UpdateText();
    }

    public void UpdateText()
    {
        TotalNumText.text = "Tri: " + TotalNum;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager Instance;
    public TriangleNumUpdater TriangleNumUpdater;
    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void AddTriNum(int addnum=1)
    {
        TriangleNumUpdater.AddTriNum(addnum);
    }
}

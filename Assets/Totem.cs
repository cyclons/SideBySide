using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : MonoBehaviour {
    [SerializeField]
    public ShapeInfo shapeInfo;
    public int UseNum = 4;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            player.shapeInfo = shapeInfo;
            player.isNearTotem = true;
            player.transform.Find("TotemHint").gameObject.SetActive(true);

        }
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Player player = collision.GetComponent<Player>();
    //    if (player != null)
    //    {
    //    }
    //}
    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            player.shapeInfo = shapeInfo;
            player.isNearTotem = false;
            player.transform.Find("TotemHint").gameObject.SetActive(false);
        }
    }
}
[System.Serializable]
public struct ShapeInfo
{
    public int[] shownTriArray;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGate : MonoBehaviour {
    public ShapeInfo PassInfo;
    public GameObject LevelPassWin;
    public bool isSuccess = false;
    public string NextSceneName;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E)&&isSuccess)
        {
            LevelManager.Instance.LoadSceneByName(NextSceneName);
            isSuccess = false;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isSuccess = true;
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            Debug.Log("player enter");

            if (player.currentShapInfo.shownTriArray == null)
            {
                isSuccess = false;

                return;
            }

            if (player.currentShapInfo.shownTriArray.Length != PassInfo.shownTriArray.Length)
            {
                Debug.Log("长度不一致"+"player:"+ player.currentShapInfo.shownTriArray.Length+"passinfo:"+ PassInfo.shownTriArray.Length);
                isSuccess = false;
                return;
            }
            for(int i=0;i< player.currentShapInfo.shownTriArray.Length; i++)
            {
                if (player.currentShapInfo.shownTriArray[i] != PassInfo.shownTriArray[i])
                {
                    isSuccess = false;
                    Debug.Log("元素不一致");
                    return;

                }
            }

            if (isSuccess)
            {
                Debug.Log("OK");
                player.transform.Find("TotemHint").gameObject.SetActive(true);
                StartCoroutine(LoadNextScene());
                LevelPassWin.SetActive(true);
            }
        }

    }
    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(1);
        LevelManager.Instance.LoadSceneByName(NextSceneName);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            player.transform.Find("TotemHint").gameObject.SetActive(false);
        }
    }

}

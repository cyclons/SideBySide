using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadWall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            Destroy(collision.gameObject);
            StartCoroutine(StartRestartScene());

        }
    }
    IEnumerator StartRestartScene()
    {
        yield return new WaitForSeconds(0.3f);
        LevelManager.Instance.RestartLevel();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour {

    private float timer = 0;
    public float JumpForce = 15;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (timer < 0.1f) { return; }
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            player.JumpSpring(transform.up.normalized* JumpForce);
            GetComponent<Animator>().SetTrigger("bounce");
            timer = 0;
        }
        else
        {
            player = collision.GetComponentInParent<Player>();
            if (player != null)
            {
                player.JumpSpring(transform.up.normalized*JumpForce);
                GetComponent<Animator>().SetTrigger("bounce");
                timer = 0;
            }
        }

    }

}

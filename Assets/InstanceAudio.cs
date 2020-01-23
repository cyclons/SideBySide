using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceAudio : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void PlayAu(AudioClip clip)
    {
        GetComponent<AudioSource>().clip = clip;
        GetComponent<AudioSource>().Play();
        Destroy(gameObject, clip.length + 0.5f);
    }
}
